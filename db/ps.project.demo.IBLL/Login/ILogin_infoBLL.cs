using System;
using System.Linq;
using System.Collections.Generic;
using FrameWorkStd.Base.IBLL;
using FrameWorkStd.Entity.Database;
using ps.project.demo.Model;

namespace ps.project.demo.IBLL
{
    /// <summary>
    /// 用户登录 业务类
    /// 创建人:彭帅
    /// 创建时间:2019/8/22 星期四
    /// </summary>
    public interface ILogin_infoBLL : IBaseBLL
	{        
        #region 保存相关操作
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        bool Insert(Login_info item);
        
        /// <summary>
        /// 插入List
        /// </summary>
        /// <returns></returns>
        /// <param name ="insertList">要插入的List</param> 
        bool InsertList(List<Login_info> insertList);
        
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        bool Delete(Login_info item);
        
        /// <summary>
        /// 删除List
        /// </summary>
        /// <returns></returns>
        /// <param name ="deleteList">要删除的List</param> 
        bool DeleteList(List<Login_info> deleteList);
        
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        bool Update(Login_info item);
        
        /// <summary>
        /// 更新List
        /// </summary>
        /// <returns></returns>
        /// <param name ="updateList">要更新的List</param> 
        bool UpdateList(List<Login_info> updateList);
        
        /// <summary>
        /// 保存List
        /// </summary>
        /// <returns></returns>
        /// <param name ="insertList">要插入的List</param> 
        /// <param name ="deleteList">要删除的List</param> 
        /// <param name ="updateList">要更新的List</param> 
        bool SaveList(List<Login_info> insertList, List<Login_info> deleteList, List<Login_info> updateList);
        #endregion
        
        #region 通用查询
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        List<Login_info> GetAllList();
        
        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        List<Login_info> GetListByWhere(QueryClause queryClause);
        
        /// <summary>
        /// 自定义查询获取记录数(用于分页查询)
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        int GetCountByWhere(QueryClause queryClause);
        
        /// <summary>
        /// 自定义查询(分页)
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        List<Login_info> GetListPageByWhere(QueryClause queryClause);
        
        /// <summary>
        /// 根据 主键 获取单条数据
        /// </summary>
        /// <returns></returns>
        /// <param name ="uuid">Uuid</param> 
        Login_info GetItemByUuid(string uuid);
        #endregion
    }
}
