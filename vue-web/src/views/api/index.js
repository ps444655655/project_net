import Plugin from 'webkf-core-global'
export const WebRequest = Plugin.$WebRequest
export const extWebRequest = Plugin.$extWebRequest
export const fileRequest = Plugin.$Filerequest

export function BaseUrl(tab) {
  const config = window.UrlConfig[tab]
  return window.UrlConfig.baseUrl[process.env.NODE_ENV][config.ServerName] + config.Url + '/' + tab
}
export default {
  WebRequest,
  extWebRequest,
  fileRequest,
  BaseUrl
}
