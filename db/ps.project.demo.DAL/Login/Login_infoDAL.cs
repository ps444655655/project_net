using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FrameWorkStd.Base.DAL;
using FrameWorkStd.Entity.Database;
using ps.project.demo.Model;
using ps.project.demo.IDAL;

namespace ps.project.demo.DAL
{
    /// <summary>
    /// 用户登录 数据库操作类
    /// 创建人:彭帅
    /// 创建时间:2019/8/22 星期四
    /// </summary>
    public class Login_infoDAL : BaseDAL, ILogin_infoDAL
	{        
        #region 通用查询
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<Login_info> GetAllList()
		{
			string sql = @"Select " + GetModelReader<Login_info>().GetFindFieldString("t") + @"
				       From " + GetModelReader<Login_info>().TableName + @" t	 ";
			List<Login_info> list = this.GetList<Login_info>(sql);
			return list;
        }
        
        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        public List<Login_info> GetListByWhere(QueryClause queryClause)
		{
			string sql = @"Select " + GetModelReader<Login_info>().GetFindFieldString("t") + @"
			               From " + GetModelReader<Login_info>().TableName + @" t ";
			string where="";
			Dictionary<string, object> paramsList =null;
			if (queryClause.QueryColumn.Count>0)
			{
				where=Environment.NewLine + GetModelReader<Login_info>().QueryColumnToWhere(queryClause.QueryColumn,where);
				paramsList = GetModelReader<Login_info>().QueryColumnToParams(queryClause.QueryColumn,paramsList);
			}
			sql=sql + Environment.NewLine + where + Environment.NewLine + ""; 
			List<Login_info> list = this.GetList<Login_info>(sql, paramsList);
			return list;
        }
        
        /// <summary>
        /// 自定义查询获取记录数(用于分页查询)
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        public int GetCountByWhere(QueryClause queryClause)
		{
			string sql = @"Select Count(*)
			               From " + GetModelReader<Login_info>().TableName + @" t " ;
			string where="";
			Dictionary<string, object> paramsList =null;
			if (queryClause.QueryColumn.Count>0)
			{
				where=Environment.NewLine + GetModelReader<Login_info>().QueryColumnToWhere(queryClause.QueryColumn,where);
				paramsList = GetModelReader<Login_info>().QueryColumnToParams(queryClause.QueryColumn,paramsList);
			}
			sql=sql + Environment.NewLine + where; 
			return this.GetFirstOrDefault<int>(sql,paramsList);
        }
        
        /// <summary>
        /// 自定义查询(分页)
        /// </summary>
        /// <returns></returns>
        /// <param name ="queryClause">查询参数</param> 
        public List<Login_info> GetListPageByWhere(QueryClause queryClause)
		{
			string sql = @"Select " + GetModelReader<Login_info>().GetFindFieldString("t") + @"
						   From " + GetModelReader<Login_info>().TableName + @" t ";
			string where="";
			Dictionary<string, object> paramsList =null;
			if (queryClause.QueryColumn.Count>0)
			{
				where = GetModelReader<Login_info>().QueryColumnToWhere(queryClause.QueryColumn,where);
				paramsList = GetModelReader<Login_info>().QueryColumnToParams(queryClause.QueryColumn,paramsList);
			}
			sql=sql + Environment.NewLine + where; 
			List<Login_info> list = this.GetList<Login_info>(sql,paramsList,"",queryClause.PageIndex,queryClause.PageSize);
			return list;
        }
        
        /// <summary>
        /// 根据 主键 获取单条数据
        /// </summary>
        /// <returns></returns>
        /// <param name ="uuid">Uuid</param> 
        public Login_info GetItemByUuid(string uuid)
		{
			string sql = @"Select " + GetModelReader<Login_info>().GetFindFieldString("t") + @"
			               From " + GetModelReader<Login_info>().TableName + @" t
				       Where t.Uuid=@uuid ";
			object sqlParameter = new { uuid = uuid };
			return this.GetFirstOrDefault<Login_info>(sql, sqlParameter);
        }
        #endregion
    }
}
