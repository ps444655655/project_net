
const utilsFunc = {
  // 树状数据线性化
  treeToArray(data) {
    let tmp = []
    Array.from(data).forEach(function(record) {
      tmp.push(record)
      if (record.children && record.children.length > 0) {
        const children = utilsFunc.treeToArray(record.children)
        tmp = tmp.concat(children)
      }
    })
    return tmp
  },
  // 比较两个单层对象是否相等(不考虑树形结构)
  isObjEqual(o1, o2, filters = []) {
    const props1 = Object.keys(o1)
    const props2 = Object.keys(o2)
    if (props1.length !== props2.length) {
      return false
    }
    for (let i = 0, max = props1.length; i < max; i++) {
      const propName = props1[i]
      if (filters.indexOf(propName) >= 0) {
        continue
      }
      if (o1[propName] !== o2[propName]) {
        return false
      }
    }
    return true
  },
  // 比较包含单层对象的两个数组是否相等
  isArrayEqual(array1, array2, filterProps = []) {
    if (array1.length !== array2.length) {
      return false
    }
    let result = true
    for (let i = 0; i < array1.length; i++) {
      result = this.isObjEqual(array1[i], array2[i], filterProps)
      if (result === false) {
        break
      }
    }
    return result
  },
  // 码表转换(包括树的上级名称)
  // field: 当前值
  // dics: 码表数组
  // key: 编码字段名
  // value: 要转换的字段名
  // 返回值： string
  exchangeCodeTable(field, dics, key = 'dictionaryId', value = 'dictionaryName') {
    for (let i = 0; i < dics.length; i++) {
      if (dics[i][key]) {
        if (dics[i][key] === field) {
          return dics[i][value]
        }
      }
    }
    return null
  },
  // 按照某一字段分组
  groupBy(array, f) {
    const groups = {}
    array.forEach(function(o) {
      const group = JSON.stringify(f(o))
      groups[group] = groups[group] || []
      groups[group].push(o)
    })
    return Object.keys(groups).map(function(group) {
      return groups[group]
    })
  },
  // 获取saveList(进行增删改对比)
  getModifyList(list, listCopy, key = 'uuid') {
    const oldList = Object.assign([], listCopy)
    const newList = Object.assign([], list)
    let insertList = []
    let deleteList = []
    const updateList = []
    /**   key
     * 判断UUID
     *  list 中的 uuid 在 listCopy 中不存在 添加
     *  listCopy 中的 uuid 在 list 中不存在 删除
     *  UUID 相等 判断 是否有更改
     */
    if (oldList.length === 0) {
      insertList = insertList.concat(newList)
    } else if (newList === 0) {
      deleteList = deleteList.concat(oldList)
    } else {
      for (let i = 0; i < newList.length; i++) {
        const newItem = newList[i]
        // 在循环中使用find再遍历oldList，利用uuid查看oldList中是否存在相同元素
        const oldItem = oldList.find((value, index, arr) => {
          return Object.is(newItem[key], value[key])
        })
        if (oldItem === undefined) {
          // 如果不存在，则表示有一个元素属于新增加元素
          insertList.push(newItem)
        } else {
          if (!this.isObjEqual(newItem, oldItem)) {
            // 如果存在，则继续比较二者是否严格相等，不相等，则说明发生更新
            updateList.push(newItem)
          }
        }
      }
      for (let i = 0; i < oldList.length; i++) {
        const oldItem = oldList[i]
        const newItem = newList.find((value, index, arr) => {
          return Object.is(oldItem[key], value[key])
        })
        if (newItem === undefined) {
          // 颠倒新旧查询顺序，使用相同原理筛选出需要删除的数据
          deleteList.push(oldItem)
        }
      }
    }
    const json = { 'insertList': insertList, 'deleteList': deleteList, 'updateList': updateList }
    return json
  },
  // 对对象进行深拷贝
  deepClone(source, filterKeys = []) {
    if (!source && typeof source !== 'object') {
      throw new Error('error arguments', 'shallowClone')
    }
    const targetObj = source.constructor === Array ? [] : {}
    Object.keys(source).forEach((keys) => {
      if (filterKeys.indexOf(keys) >= 0) {
        targetObj[keys] = null
        return
      }
      if (source[keys] && typeof source[keys] === 'object') {
        targetObj[keys] = this.deepClone(source[keys], filterKeys)// 此处this的指向是utilsFunc
      } else {
        targetObj[keys] = source[keys]
      }
    })
    return targetObj
  },
  // 拼接父子对象(只拼接一级)
  getFatherAndChildren(fatherData) {
    const children = utilsFunc.deepClone(fatherData.children, ['children'])
    const father = utilsFunc.deepClone(fatherData, ['children'])
    if (children.length > 0) {
      father.hasChild = true
    }
    children.unshift(father)
    return children
  },
  // 构建uuid
  createUuid() {
    const s = []
    const hexDigits = '0123456789abcdef'
    for (var j = 0; j < 36; j++) {
      s[j] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1)
    }
    s[14] = '4'
    s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1)
    s[8] = s[13] = s[18] = s[23] = '-'
    const uuid = s.join('')
    return uuid
  },
  // 首字母转换成小写
  replaceStr(str) {
    let strTemp = '' // 新字符串
    for (let i = 0; i < str.length; i++) {
      if (i === 0) {
        strTemp += str[i].toLowerCase() // 第一个
        continue
      }
      if (str[i] === ' ' && i < str.length - 1) { // 空格后
        strTemp += ' '
        strTemp += str[i + 1].toLowerCase()
        i++
        continue
      }
      strTemp += str[i]
    }
    return strTemp
  },
  // 移动数组
  moveInArray(arr, fromIndex, toIndex) {
    if (fromIndex !== toIndex) {
      const element = arr[fromIndex]
      arr.splice(fromIndex, 1)
      arr.splice(toIndex, 0, element)
    }
  },
  // 获取合适的表格编码(侧重于数字编码且带有父子关系)
  getProperColCode(list, field, start = 1) {
    const colCodes = []
    for (let i = start; i < list.length; i++) {
      const item = list[i]
      if (!isNaN(item[field])) {
        colCodes.push(item[field])
      }
    }
    const maxValue = Math.max.apply(null, colCodes) + 1
    let result = maxValue.toString()
    let pIdLength = 0
    if (list[0].parentId) {
      pIdLength = list[0].parentId.length === 0 ? 3 : list[0].parentId.length
    } else {
      pIdLength = 1
    }
    const count = pIdLength + 2 - result.length
    for (let j = 0; j < count; j++) {
      result = '0' + result
    }
    return result
  }
}

export default utilsFunc
