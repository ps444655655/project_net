using System;

namespace ps.project.demo.Enum
{
    /// <summary>
    /// 路由:*-test-*
    /// 创建人:彭帅
    /// 创建时间:2019/08/22
    /// </summary>
    public struct Connection
	{        
        /// <summary>
        /// 当前模块主连接
        /// </summary>
        public static readonly string Maintest = "Maintest";

        /// <summary>
        /// 当前模块只读连接
        /// </summary>
        public static readonly string ReadOnlytest = "ReadOnlytest";
    }
}
