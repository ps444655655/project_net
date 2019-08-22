using FrameWorkStd.Entity;
using FrameWorkStd.Global;
using FrameWorkStd.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using FrameWork.AspNetCore.WebDataBus.Hubs;
using Microsoft.AspNetCore.Mvc;
using FrameWork.DriveAspNetCore.DIRegister;
using FrameWork.DriveAspNetCore.HelpApi;
using FrameWorkStd.Log.Base;
using System.Linq;

namespace ps.project.demo.Service
{
    /// <summary>
    /// 配置请求管道
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 配置文件实体
        /// </summary>
        private IConfiguration _configuration { get; }

        /// <summary>
        /// 构造函数，加载配置文件
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 注入服务到容器中
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region 注入业务配置
            services.UseBusinessByConfigureServices(_configuration);
            #endregion

            #region 注入API文档
            services.UseHelpApiByConfigureServices(_configuration, GlobalConst.AssemblyName);
            #endregion

            #region 服务相关
            services
                .AddMvc()
                .AddXmlSerializerFormatters() //设置支持XML格式输入输出
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOptions();
            #endregion

            #region 初始化配置文件
            InitConfig(services);
            #endregion

            #region 初始化缓存数据
            try
            {
                InitCacheData();
            }
            catch (Exception ex)
            {
                ex.ToException();
            }
           
            #endregion

            #region 注入SignalR
            try
            {
                if (_configuration.GetSection("WebBus:AllowWebBus").ToBool())
                {
                    services.AddTransient<GlobalHubServer<ApplicationHub>>();
                    services.AddTransient<ApplicationHub>();
                }
            }
            catch (Exception ex)
            {
                ex.ToException();
            }
            #endregion
        }

        /// <summary>
        /// 添加中间件到Request请求管道中
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        ///  <param name="serviceProvider"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            #region 服务相关
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            #endregion

            #region 注入中间件
            app.UseBusinessByConfigure(env, _configuration);
            #endregion

            #region 注入API文档
            app.UseHelpApiByBusinessConfigure(_configuration, GlobalConst.AssemblyName, GlobalConst.BaseRoute);
            #endregion

            #region 注册signalr服务 
            try
            {
                if (_configuration.GetSection("WebBus:AllowWebBus").ToString().ToLower() == "true")
                {
                    app.UseSignalR(routes =>
                    {
                        routes.MapHub<ApplicationHub>(GlobalConst.RouteWsName + "/hub");
                    });
                    serviceProvider.GetService<GlobalHubServer<ApplicationHub>>();
                }
            }
            catch (Exception ex)
            {
                ex.ToException();
            }
            #endregion
        }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public void InitConfig(IServiceCollection services)
        {
            //services.Configure<List<ApiModel>>(_configuration.GetSection("Interface"));
            //GlobalInfo.ListApiModel = _configuration.GetSection("Interface").GetChildren().ToJson().ToList<ApiModel>();
            //GlobalInfo.ListApiModel = (List<ApiModel>)_configuration.GetSection("Interface");


        }

        /// <summary>
        /// 初始化缓存数据
        /// </summary>
        public void InitCacheData()
        {
			if (!GlobalInfo.AllowLoadCache) return;

            //@创建初始化@
        }
    }
}
