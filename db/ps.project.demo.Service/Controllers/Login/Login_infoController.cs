using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWorkStd.Entity;
using FrameWorkStd.Enum;
using FrameWorkStd.Log.Base;
using FrameWork.BaseAspNetCore.API;
using Microsoft.AspNetCore.Authorization;
using FrameWorkStd.Entity.Database;
using Microsoft.AspNetCore.Mvc;
using ps.project.demo.IBLL;
using ps.project.demo.Model;

namespace ps.project.demo.Service
{
    /// <summary>
    /// 用户登录 API服务
    /// 创建人:彭帅
    /// 创建时间:2019/8/22 星期四
    /// </summary>
    [Route(GlobalConst.RouteName)]
    public class Login_infoController : BaseAPI
	{        
        #region 定义变量
        private readonly ILogin_infoBLL bll;
        #endregion
        
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name ="bll">注入BLL</param> 
        public Login_infoController(ILogin_infoBLL bll)
		{
            this.bll = bll;
        }
        #endregion
        
        #region 默认Get
        /// <summary>
        /// 默认GET
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public QueryResultModel Get()
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				returnValue.Data = "用户登录 服务";
				return returnValue;
			}
			catch (Exception ex)
			{
			    returnValue.Code = QueryActionResult.ServerError;
			    returnValue.Message = ex.Message;
			    return returnValue;
			}
        }
        #endregion
        
        #region 保存相关操作
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        [HttpPost("Insert")]
        public QueryResultModel Insert([FromBody]Login_info item)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				bool result=bll.Insert(item);
				//返回数据
				returnValue.Data = result;
				return returnValue;
			}
			catch (Exception ex)
			{
				returnValue.Code = QueryActionResult.ServerError;
				returnValue.Message = ex.Message;
				return returnValue;
			}
        }
        
        /// <summary>
        /// 插入List
        /// </summary>
        /// <returns></returns>
        /// <param name ="insertList">要插入的List</param> 
        [HttpPost("InsertList")]
        public QueryResultModel InsertList([FromBody]List<Login_info> insertList)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				bool result=bll.InsertList(insertList);
				//返回数据
				returnValue.Data = result;
				return returnValue;
			}
			catch (Exception ex)
			{
				returnValue.Code = QueryActionResult.ServerError;
				returnValue.Message = ex.Message;
				return returnValue;
			}
        }
        
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        [HttpPost("Delete")]
        public QueryResultModel Delete([FromBody]Login_info item)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				bool result=bll.Delete(item);
				//返回数据
				returnValue.Data = result;
				return returnValue;
			}
			catch (Exception ex)
			{
				returnValue.Code = QueryActionResult.ServerError;
				returnValue.Message = ex.Message;
				return returnValue;
			}
        }
        
        /// <summary>
        /// 删除List
        /// </summary>
        /// <returns></returns>
        /// <param name ="deleteList">要删除的List</param> 
        [HttpPost("DeleteList")]
        public QueryResultModel DeleteList([FromBody]List<Login_info> deleteList)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				bool result=bll.DeleteList(deleteList);
				//返回数据
				returnValue.Data = result;
				return returnValue;
			}
			catch (Exception ex)
			{
				returnValue.Code = QueryActionResult.ServerError;
				returnValue.Message = ex.Message;
				return returnValue;
			}
        }
        
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        [HttpPost("Update")]
        public QueryResultModel Update([FromBody]Login_info item)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				bool result=bll.Update(item);
				//返回数据
				returnValue.Data = result;
				return returnValue;
			}
			catch (Exception ex)
			{
				returnValue.Code = QueryActionResult.ServerError;
				returnValue.Message = ex.Message;
				return returnValue;
			}
        }
        
        /// <summary>
        /// 更新List
        /// </summary>
        /// <returns></returns>
        /// <param name ="updateList">要更新的List</param> 
        [HttpPost("UpdateList")]
        public QueryResultModel UpdateList([FromBody]List<Login_info> updateList)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				bool result=bll.UpdateList(updateList);
				//返回数据
				returnValue.Data = result;
				return returnValue;
			}
			catch (Exception ex)
			{
				returnValue.Code = QueryActionResult.ServerError;
				returnValue.Message = ex.Message;
				return returnValue;
			}
        }
        
        /// <summary>
        /// 保存List
        /// </summary>
        /// <returns></returns>
        /// <param name ="saveParameter">要保存的List（包括InsertList、DeleteList、UpdateList）</param> 
        [HttpPost("SaveList")]
        public QueryResultModel SaveList([FromBody]SataDataParameter saveParameter)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//定义实体
				List<Login_info> insertList = new List<Login_info>();
				List<Login_info> deleteList = new List<Login_info>();
				List<Login_info> updateList = new List<Login_info>();
				//转换数据
				if (saveParameter.InsertList != null && saveParameter.InsertList.Count > 0) insertList = saveParameter.InsertList.ToObject<List<Login_info>>();
				if (saveParameter.DeleteList != null && saveParameter.DeleteList.Count > 0) deleteList = saveParameter.DeleteList.ToObject<List<Login_info>>();
				if (saveParameter.UpdateList != null && saveParameter.UpdateList.Count > 0) updateList = saveParameter.UpdateList.ToObject<List<Login_info>>();
			    //保存数据
			    bool result=bll.SaveList(insertList , deleteList , updateList);
				//返回数据
				returnValue.Data = result;
				return returnValue;
			}
			catch (Exception ex)
			{
				returnValue.Code = QueryActionResult.ServerError;
				returnValue.Message = ex.Message;
				return returnValue;
			}
        }
        #endregion
        
        #region 通用查询
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllList")]
        public QueryResultModel GetAllList()
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				List<Login_info> list=bll.GetAllList();
				//返回数据
				returnValue.Data = list;
				return returnValue;
			}
			catch (Exception ex)
			{
			    returnValue.Code = QueryActionResult.ServerError;
			    returnValue.Message = ex.Message;
			    return returnValue;
			}
        }
        
        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        [HttpPost("GetListByWhere")]
        public QueryResultModel GetListByWhere(QueryClause queryClause)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				List<Login_info> list=bll.GetListByWhere(queryClause);
				//返回数据
				returnValue.Data = list;
				return returnValue;
			}
			catch (Exception ex)
			{
			    returnValue.Code = QueryActionResult.ServerError;
			    returnValue.Message = ex.Message;
			    return returnValue;
			}
        }
        
        /// <summary>
        /// 自定义查询(分页)
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        [HttpPost("GetListPageByWhere")]
        public QueryResultModelByPage GetListPageByWhere([FromBody]QueryClause queryClause)
		{
			QueryResultModelByPage returnValue = new QueryResultModelByPage();
			try
			{
				//获取数据
				List<Login_info> list=bll.GetListPageByWhere(queryClause);
				//获取总记录数
				int total=bll.GetCountByWhere(queryClause);
				//返回数据
				returnValue.Data = list;
				returnValue.Total = total;
				return returnValue;
			}
			catch (Exception ex)
			{
			    returnValue.Code = QueryActionResult.ServerError;
			    returnValue.Message = ex.Message;
			    return returnValue;
			}
        }
        
        /// <summary>
        /// 根据 主键 获取单条数据
        /// </summary>
        /// <returns></returns>
        /// <param name ="uuid">Uuid</param> 
        [HttpGet("GetItemByUuid")]
        public QueryResultModel GetItemByUuid(string uuid)
		{
			QueryResultModel returnValue = new QueryResultModel();
			try
			{
				//获取数据
				Login_info item=bll.GetItemByUuid(uuid);
				//返回数据
				returnValue.Data = item;
				if(item == null)returnValue.Code = 0;
				return returnValue;
			}
			catch (Exception ex)
			{
			    returnValue.Code = QueryActionResult.ServerError;
			    returnValue.Message = ex.Message;
			    return returnValue;
			}
        }
        #endregion
    }
}
