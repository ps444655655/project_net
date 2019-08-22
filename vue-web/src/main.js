import Vue from 'vue'
import App from './App'
import router from './router'
import Plugin from 'webkf-core-global'
import './style/index.scss'
import xhzqDialog from 'webkf-core-dialog'
import lookUp from 'webkf-core-lookup'
import 'webkf-core-dialog/dist/xhzqDialog.min.css'
// import xhzqDialog from '@/components/xhzqDialog'
import { LicenseManager } from 'ag-grid-enterprise'
import uploader from 'vue-simple-uploader'
LicenseManager.setLicenseKey('LinkSoft_on_behalf_of_DaLian_ZQSoft_ZqMes_1Devs27_March_2020__MTU4NTI2NzIwMDAwMA==d635fd35d91d079c17ee0cba737b2b45')
Vue.use(Plugin)
Vue.use(uploader)
Vue.prototype.$Bus = Plugin.$Bus
Vue.component(xhzqDialog.name, xhzqDialog)
Vue.component('lookUp', lookUp)
new Vue({
  el: '#app',
  router,
  render: h => h(App)
})
