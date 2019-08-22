using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ps.project.demo.Service;

namespace SYS.Modular.Service
{
    /// <summary>
    /// 服务主文件
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 启动项
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            ////生成本地公有Key文件
            //LicenseHelper.GeneratePublicKeyFile(GlobalConst.BasePath);
            //string key = LicenseHelper.GenerateRandomKey();

            ////每一小时更新一次最后执行时间，用于授权验证
            //Timer myTimer = new Timer(LicenseHelper.UpdateLicenseLastStartTime, GlobalConst.BasePath, 30 * 1000, 60 * 60 * 1000);//30秒后第一次调用，每1小时调用一次  
            FrameWork.DriveAspNetCore.DIRegister.DIServer.ServiceRun(BuildWebHost(args), args);
        }

        /// <summary>
        /// 构建Web主机
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args)
        {
            //初始化WebHost
            IWebHostBuilder webHostBuilder = FrameWork.DriveAspNetCore.DIRegister.DIServer.CreateBuildWebHost(args);

            //设置启动
            webHostBuilder.UseStartup<Startup>();
            return webHostBuilder.Build();

        }
    }
}
