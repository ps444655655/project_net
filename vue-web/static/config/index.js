const baseUrl = {
  development: {
    serverNameA: 'http://localhost:10001/'
  },
  production: {
    // serverNameA: 'http://xhzqdb.imwork.net:6100/',
    // serverNameB: 'http://xhzqdb.imwork.net:10100/',
    // flowService: 'http://172.16.120.93/Sentury_Lims/'
  }
}

window.UrlConfig = {
  baseUrl: baseUrl,
  // 权限表
  Login_info: {
    ServerName: 'serverNameA',
    Url: 'test'
  }
}

// // 引用静态资源
const iconfont = [
  './static/iconfont/Menu/iconfont.css',
  './static/iconfont/Tool/iconfont.css'
]

// 网站基础配置
window.pageConfig = {
  SiteName: 'Psmart Project',
  iconfont: iconfont
}
