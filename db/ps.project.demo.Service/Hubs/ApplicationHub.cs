using FrameWork.AspNetCore.WebDataBus.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ps.project.demo.Service
{
    /// <summary>
    /// SignalR全局Hub
    /// </summary>
    public class ApplicationHub : BaseAppHub
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly GlobalHubServer<ApplicationHub> _hubMethods;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hubMethods"></param>
        public ApplicationHub(GlobalHubServer<ApplicationHub> hubMethods)
        {
            _hubMethods = hubMethods;
        }

        #region 发送信息操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        #endregion
    }
}