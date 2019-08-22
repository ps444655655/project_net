using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWorkStd.Entity.Database;
using FrameWorkStd.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ps.project.demo.Service.Controllers
{
    /// <summary>
    /// 对外健康检测服务
    /// 创建人:彭帅
    /// 创建时间:2019/08/22
    /// </summary>
    [AllowAnonymous]
    [Route(GlobalConst.RouteName)]
    [Produces("application/json")]
    public class HealthController : Controller
    {
        /// <summary>
        /// 主健康检查
        /// </summary>
        /// <returns></returns>
        [HttpGet("Check")]
        public QueryResultModel Check()
        {
            QueryResultModel returnValue = new QueryResultModel();
            try
            {
                string Namespace = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                returnValue.Data = Namespace + " 检查成功";
                return returnValue;
            }
            catch (Exception ex)
            {
                returnValue.Code = QueryActionResult.ServerError;
                returnValue.Message = ex.Message;
                return returnValue;
            }
        }
    }
}
