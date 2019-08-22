sc create SYS.Modular.Service  binPath= "\"C:/program files/dotnet/dotnet.exe\" \"D:/XHZQ_Core_Server/ZQEMP_Server/ps.project.demo.Service/ps.project.demo.Service.dll\"" DisplayName= "练习模块" start= auto
sc description ps.project.demo.Service  "练习模块"
sc config ps.project.demo.Service  type= interact type= own
sc start ps.project.demo.Service