<template>
 <div class="wrapper">
    <div class="header">
       <span class="title">登录页面</span>
    </div>
    <div class="main">
      <el-form :model="ruleForm" status-icon ref="ruleForm" label-width="50px" class="demo-ruleForm">
        <el-form-item label="账号" prop="pass">
          <el-input type="input" v-model="ruleForm.input" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="checkPass">
          <el-input type="password" v-model="ruleForm.checkPass" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="onLogin">登 录</el-button>
          <el-button type="primary" @click="onLogon">注 册</el-button>
        </el-form-item>
      </el-form>
    </div>
 </div>
</template>

<script>
import { GetAllList } from '../api/Login'
export default {
  components: {},
  data() {
    return {
      data: [],
      ruleForm: {
        input: '',
        checkPass: ''
      }
    }
  },
  // 父传子的props
  props: {},
  // 计算属性
  computed: {},
  // 监控data中的数据变化
  watch: {},
  // 方法集合
  methods: {
    // 查询账户数据
    getALLData() {
      GetAllList().then((res) => {
        this.data = res
      })
    },
    // 登录
    onLogin() {
      console.log(this.data)
      this.data.forEach(item => {
        console.log(item.accountNum)
      })
    },
    // 注册
    onLogon() {
      alert('壮壮2嘛？')
    }
  },
  // 函数表达式
  filters: {},
  beforeCreate() {}, // 生命周期 - 创建之前
  created() {}, // 生命周期 - 创建完成(可以访问当前this实例)
  beforeMount() {}, // 生命周期 - 挂载之前
  mounted() {
    this.getALLData()
  }, // 生命周期 - 挂载完成(可以访问DOM元素)
  beforeUpdate() {}, // 生命周期 - 更新之前
  updated() {}, // 生命周期 - 更新之后
  beforeDestroy() {}, // 生命周期 - 销毁之前
  destroyed() {}, // 生命周期 - 销毁完成
  activated() {} // 如果页面有keep-alive缓存功能，这个函数会触发
}
</script>
<style lang='scss' scoped>
 .wrapper{
   .main{
     padding: 20px;
     margin-top: 50px;
   }
 }
</style>