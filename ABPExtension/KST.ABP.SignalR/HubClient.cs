using System;
using System.Collections.Generic;
using System.Text;

namespace KST.ABP.SignalR
{
    public class HubClient
    {
        public string ConnectionId { get; set; }

        public Guid? TenantId { get; set; }

        public Guid? UserId { get; set; }
        /// <summary>
        /// 为不同的hub标识的唯一code
        /// </summary>
        public string UniqueCode { get; set; }
        public DateTime ConnectTime { get; set; }
    }
}
