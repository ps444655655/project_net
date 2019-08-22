# V4框架系统服务

### 说明

 默认端口 6201
 测试控制台运行 dotnet ./SYS.Modular.Service.dll --console
 配置文件需要设置成 "内容","始终复制"


### NuGet配置说明 
私有NuGet服务 http://xhzq.com:8091/nuget/
设置方法请参考 http://www.xhzq.com/wordpress/archives/555

![screenshot](http://www.xhzq.com/wordpress/wp-content/uploads/2019/01/img_5c36b08bb67b2.png)


### 配置文件

> * appsettings.json                公有配置文件
> * appsettings.Development.json    开发配置文件
> * appsettings.Production.json     发布配置文件
> * ExceptionlessConfig.json        日志Exceptionless配置文件
> * nlog.config                     日志nlog配置文件
> * redissettings.json              缓存redis 配置文件



### 批处理 

 注册服务 RegService.bat                  
 运行服务 RunService.bat                  


### 服务配置说明 

 注册服务: sc create 服务名 binPath= "文件路径" DisplayName= "服务显示名" start= auto                   
 修改描述: sc description 服务名  "服务描述内容"                   
 做面交互: sc config 服务名  type= interact type= own                   
 启动服务: sc start 服务名                   
 停止任务: sc stop 服务名                   
 删除任务: sc delete 服务名                   



