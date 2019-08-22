import { BaseUrl, WebRequest } from '@/views/api/index'
const baseUrl = BaseUrl('SyURoleInfo')

export function GetRoleFunctionListByTree(roleId, menuId) {
  const params = {
    roleId,
    menuId,
    enabled: true
  }
  return WebRequest({
    url: baseUrl + '/GetAuthorization',
    method: 'get',
    params
  })
}
