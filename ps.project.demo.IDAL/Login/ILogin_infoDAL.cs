using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FrameWorkStd.Base.IDAL;
using FrameWorkStd.Entity.Database;
using ps.project.demo.Model;

namespace ps.project.demo.IDAL
{
    /// <summary>
    /// 用户登录 数据库操作类
    /// 创建人:彭帅
    /// 创建时间:2019/8/22 星期四
    /// </summary>
    public interface ILogin_infoDAL : IBaseDAL
	{        
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
