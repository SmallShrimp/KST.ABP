using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Security;
using Volo.Abp.Timing;
using Volo.Abp.Users;

namespace KST.ABP.SignalR
{
    public abstract class SignlarHubBase : Hub
    {

        protected string Code = "";
        protected ICurrentUser CurrentUser { get; set; }
        protected IServiceProvider ServiceProvider;
        protected readonly HubClientPool _hubPool;
        protected IClock Clock;

        public SignlarHubBase(
            ICurrentUser currentUser,
            HubClientPool hubPool,
            IServiceProvider serviceProvider,
            IClock clock,
            string code)
        {
            CurrentUser = currentUser;
            _hubPool = hubPool;
            ServiceProvider = serviceProvider;
            Clock = clock;
            Code = code;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            var client = new HubClient()
            {
                ConnectionId = Context.ConnectionId,
                TenantId = CurrentUser.TenantId,
                UserId = CurrentUser.Id,
                UniqueCode = Code,
                ConnectTime = Clock.Now
            };
            _hubPool.AddIfNotContain(client, true);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            _hubPool.Remove(Context.ConnectionId);
        }
    }
}
