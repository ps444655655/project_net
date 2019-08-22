using System;
using System.Linq;
using System.Collections.Generic;
using FrameWorkStd.Base.BLL;
using FrameWorkStd.Entity.Database;
using FrameWorkStd.Log.Base;
using FrameWorkStd.Util;
using FrameWorkStd.Global;
using ps.project.demo.IBLL;
using ps.project.demo.IDAL;
using ps.project.demo.Model;
using ps.project.demo.Enum;

namespace ps.project.demo.BLL
{
    /// <summary>
    /// 用户登录 业务类
    /// 创建人:彭帅
    /// 创建时间:2019/8/22 星期四
    /// </summary>
    public class Login_infoBLL : BaseBLL, ILogin_infoBLL
	{        
        #region 定义变量
        private readonly ILogin_infoDAL dal;
        #endregion
        
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name ="dal">注入DAL</param> 
        public Login_infoBLL(ILogin_infoDAL dal)
		{
            this.dal = dal;
        }
        #endregion
        
        #region 保存相关操作
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        public bool Insert(Login_info item)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				this.SetInsertDefault(item);
				return dal.Insert(item);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 插入List
        /// </summary>
        /// <returns></returns>
        /// <param name ="insertList">要插入的List</param> 
        public bool InsertList(List<Login_info> insertList)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				this.SetInsertDefault(insertList);
				return dal.InsertList(insertList);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        public bool Delete(Login_info item)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.Delete(item);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 删除List
        /// </summary>
        /// <returns></returns>
        /// <param name ="deleteList">要删除的List</param> 
        public bool DeleteList(List<Login_info> deleteList)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.DeleteList(deleteList);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        public bool Update(Login_info item)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				this.SetUpdateDefault(item);
				return dal.Update(item);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 更新List
        /// </summary>
        /// <returns></returns>
        /// <param name ="updateList">要更新的List</param> 
        public bool UpdateList(List<Login_info> updateList)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				this.SetUpdateDefault(updateList);
				return dal.UpdateList(updateList);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 保存List
        /// </summary>
        /// <returns></returns>
        /// <param name ="insertList">要插入的List</param> 
        /// <param name ="deleteList">要删除的List</param> 
        /// <param name ="updateList">要更新的List</param> 
        public bool SaveList(List<Login_info> insertList, List<Login_info> deleteList, List<Login_info> updateList)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.SaveList(insertList , deleteList , updateList);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        #endregion
        
        #region 保存默认值操作
        /// <summary>
        /// 设置添加默认值
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        private void SetInsertDefault(Login_info item)
		{
        }
        
        /// <summary>
        /// 设置添加默认值
        /// </summary>
        /// <returns></returns>
        /// <param name ="insertList">要插入的List</param> 
        private void SetInsertDefault(List<Login_info> insertList)
		{
			foreach (var item in insertList)
			{
			    this.SetInsertDefault(item);
			}
        }
        
        /// <summary>
        /// 设置修改默认值
        /// </summary>
        /// <returns></returns>
        /// <param name ="item"></param> 
        private void SetUpdateDefault(Login_info item)
		{
        }
        
        /// <summary>
        /// 设置修改默认值
        /// </summary>
        /// <returns></returns>
        /// <param name ="updateList">要更新的List</param> 
        private void SetUpdateDefault(List<Login_info> updateList)
		{
			foreach (var item in updateList)
			{
			    this.SetUpdateDefault(item);
			}
        }
        #endregion
        
        #region 通用查询
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<Login_info> GetAllList()
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.GetAllList();
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        public List<Login_info> GetListByWhere(QueryClause queryClause)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.GetListByWhere(queryClause);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 自定义查询获取记录数(用于分页查询)
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        public int GetCountByWhere(QueryClause queryClause)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.GetCountByWhere(queryClause);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 自定义查询(分页)
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        public List<Login_info> GetListPageByWhere(QueryClause queryClause)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.GetListPageByWhere(queryClause);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        
        /// <summary>
        /// 根据 主键 获取单条数据
        /// </summary>
        /// <returns></returns>
        /// <param name ="uuid">Uuid</param> 
        public Login_info GetItemByUuid(string uuid)
		{
			try
			{
				dal.Open(this.GetDbConnectionInfo(Connection.Maintest));
				return dal.GetItemByUuid(uuid);
			}
			catch (Exception ex)
			{
				throw ex.ToException();
			}
        }
        #endregion
    }
}
