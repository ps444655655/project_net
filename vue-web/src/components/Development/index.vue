<template>
  <xhzqDialog ref="xhzqDialog" title="开发环境" :width="'300px'" :isFooter="false">
    <div class="login-container">
      <el-form
        class="login-form"
        autoComplete="on"
        ref="loginForm"
        :model="loginForm"
        :rules="loginRules"
        label-position="left"
      >
        <!-- 账套 -->
        <el-form-item
          prop="ledgerId"
        >
          <span class="el-icon-upload icon"></span>
          <el-select
            v-model="loginForm.ledgerId"
            placeholder="请选择账套"
            style="width:100%;"
            v-loading="ZTloading"
            element-loading-spinner="el-icon-loading"
            element-loading-background="rgba(255, 255, 255, 0.5)"
          >
            <el-option
              v-for="item in ledgers"
              :key="item.dictionaryId"
              :label="item.dictionaryName"
              :value="item.dictionaryId"
            >
            </el-option>
          </el-select>
        </el-form-item>
        <!-- username -->
        <el-form-item prop="userId">
          <span class="iconfont icon-user- icon"></span>
          <el-input
            name="userId"
            type="text"
            v-model="loginForm.userId"
            autoComplete="on"
            placeholder="账号"
          />
        </el-form-item>
        <!-- password -->
        <el-form-item prop="password">
          <span class="el-icon-goods icon"></span>
          <el-input
            name="password"
            :type="pwdType"
            v-model="loginForm.password"
            autoComplete="on"
            placeholder="密码"
          >
          </el-input>
        </el-form-item>
        <el-form-item>
          <el-button
            class="el-button"
            :loading="loading"
            @click.native.prevent="handleLogin"
            type="primary"
          >
            登录
          </el-button>
        </el-form-item>
      </el-form>
    </div>
  </xhzqDialog>
</template>
<script>
  import { isvalidUsername } from './validate'
  import loginApi from '@/views/api/Login'
  const api = loginApi.api
  export default {
    name: 'dev_env',
    data() {
      const validateledgerId = (rule, value, callback) => {
        if (value === '') {
          callback(new Error('请选择账套'))
        } else {
          callback()
        }
      }
      const validateUsername = (rule, value, callback) => {
        if (!isvalidUsername(value)) {
          callback(new Error('请输入正确的用户名'))
        } else {
          callback()
        }
      }
      const validatePass = (rule, value, callback) => {
        if (value.length < 5) {
          callback(new Error('密码不能小于5位'))
        } else {
          callback()
        }
      }
      return {
        menuData: [],
        active: '',
        isCollapse: false,
        loginForm: {
          ledgerId: '',
          shiftId: '',
          userId: 'admin',
          password: '123456'
        },
        loginRules: {
          ledgerId: [{ required: true, trigger: 'blur', validator: validateledgerId }],
          userId: [{ required: true, trigger: 'blur', validator: validateUsername }],
          password: [{ required: true, trigger: 'blur', validator: validatePass }]
        },
        loading: false,
        ZTloading: true,
        pwdType: 'password',
        ledgers: [],
        step: '' // login or menu
      }
    },
    mounted() {
      if (process.env.NODE_ENV === 'development') {
        if (!this.$private_getToken()) {
          this.fetchLedgers()
          this.$refs.xhzqDialog.openDialog()
        }
      }
    },
    methods: {
      fetchLedgers() {
        api.getLedgerInfo().then(res => {
          this.ledgers = res
          this.ZTloading = false
          if (res !== null) {
            this.loginForm.ledgerId = res[0].dictionaryId
          }
        }).catch(() => {
          this.loading = false
        })
      },
      handleLogin() {
        this.$refs.loginForm.validate(valid => {
          if (valid) {
            this.loading = true
            api.login(this.loginForm.ledgerId, this.loginForm.userId, this.loginForm.password).then(response => {
              const data = response
              this.$private_setToken(data.access_token)
              this.$private_setTokenType(data.token_type)
              this.$refs.xhzqDialog.closeDialog()
            })
          } else {
            return false
          }
        })
      }
    }
  }
</script>
<style lang="scss">
  // 输入框样式
  $dw:4.5vh;
  .login-container {
    .logoImgs{
      margin-bottom: 5vh;
    }
    .el-form{
      .el-form-item{
        margin-bottom: 1.5vh;
        .el-form-item__content{
          background: #fff;
          border: 1px solid #ccc;
          position: relative;
          display: flex;
          border-radius: $dw/2;
          height: $dw;
          overflow: hidden;
          .icon{
            display: inline-block;
            height: 100%;
            line-height: $dw;
            margin-left: $dw/2;
            background: #fff;
          }
          .el-select{
            height: 100%;
            .el-input{
              height: 100%;
              .el-input__inner{
                height: 100%;
              }
              .el-input__suffix{
                line-height: $dw;
                color:#b0b3b2;
              }
            }
          }
          .el-button{
            width: 100%;
            height: 100%;
            padding:0;
            font-family: ArialMT;
            &:hover{
              opacity: 0.9;
            }
            span{
              font-size:2rem;
            }
          }
        }
      }
      input{
        background: #fff;
        border:0;
        height: 100%;
        position: absolute;
        color:#80868b;
        font-size: 1.5rem;
      }
    }
  }
</style>

