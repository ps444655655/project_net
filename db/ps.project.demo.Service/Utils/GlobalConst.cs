using Microsoft.Extensions.PlatformAbstractions;

namespace ps.project.demo.Service
{
    /// <summary>
    /// 全局工具类
    /// </summary>
    public class GlobalConst
    {
        /// <summary>
        /// 当前应用的命名空间
        /// </summary>
        public readonly static string AssemblyName = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;

        /// <summary>
        /// 当前应用程序路径
        /// </summary>
        public readonly static string BasePath = PlatformServices.Default.Application.ApplicationBasePath;

        /// <summary>
        /// 路由名
        /// </summary>
        public const string BaseRoute = "test";

        /// <summary>
        /// 默认路由名
        /// </summary>
        public const  string RouteName = BaseRoute + "/[controller]";

        /// <summary>
        /// WebSocket路由名
        /// </summary>
        public const string RouteWsName = "/" + BaseRoute + "Ws";
    }
}
