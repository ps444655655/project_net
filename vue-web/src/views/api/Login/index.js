import { BaseUrl, WebRequest } from '../index'
const baseUrl = BaseUrl('Login_info')
export function GetAllList() {
  return WebRequest({
    url: baseUrl + '/GetAllList',
    method: 'get',
    params: ''
  })
}

export function Insert(item) {
  return WebRequest({
    url: baseUrl + '/Insert',
    method: 'post',
    data: item
  })
}

export function Update(item) {
  return WebRequest({
    url: baseUrl + '/Update',
    method: 'post',
    data: item
  })
}

export function Delete(item) {
  return WebRequest({
    url: baseUrl + '/Delete',
    method: 'post',
    data: item
  })
}
export default {
  GetAllList,
  Insert,
  Update,
  Delete
}
