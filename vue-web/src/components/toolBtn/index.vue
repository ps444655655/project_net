<template>
  <div class="index" v-loading="toolFlag" :style="align === 'left'? 'justify-content: flex-start': 'justify-content: flex-end' ">
    <slot></slot>
    <div class="btnGourp" v-for="item in toolData">
      <el-button :icon="item.icon" @click="CallClick(item.runFunction)">{{item.functionName}}</el-button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'toolBtn',
  data() {
    return {
      toolFlag: true,
      toolData: []
    }
  },
  // props: ['toolBtnData', 'align'],
  props: {
    toolBtnData: {
      type: Array,
      default: function() {
        return {}
      }
    },
    align: {
      type: String,
      default: 'right'
    },
    formId: {
      type: String
    }
  },
  watch: {
    toolBtnData: {
      handler: function() {
        if (this.toolBtnData.length > 0) {
          this.setData()
        }
      },
      deep: true,
      immediate: true
    }
  },
  methods: {
    CallClick(value) {
      if (this.$parent[value] !== undefined) {
        this.$parent[value]()
        console.log(value)
      } else {
        console.error('toolBtn --> 权限按钮组中 ' + value + '方法没定义')
      }
    },
    setData() {
      const data = this.toolBtnData.find((item) => { return item.formId === this.formId })
      if (data) {
        this.toolData = data.listSyURoleByFunction
      } else {
        this.toolData = []
      }
      this.toolFlag = false
    }
  }
}
</script>

<style lang='scss' scoped>
  .index {
    height:100%;
    width: 100%;
    display: flex;
    align-items: center;
    .btnGourp{
      margin: 0 2px;
    }
  }
</style>
