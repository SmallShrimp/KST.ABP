using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace KST.ABP.SignalR
{
    public class HubClientPool : ISingletonDependency
    {
        private readonly IList<HubClient> hubClients;
        public HubClientPool()
        {
            hubClients = new List<HubClient>();
        }

        public HubClient GetByConnId(string connectionId)
        {
            ClearNullItem();
            return hubClients
                .Where(m => m != null && m.ConnectionId == connectionId)
                .FirstOrDefault();
        }

        public IList<HubClient> GetByUserId(Guid? uid)
        {
            ClearNullItem();
            return hubClients.Where(m => m != null && m.UserId == uid).ToList();
        }

        public IList<HubClient> GetByCode(string code)
        {
            ClearNullItem();
            return hubClients.Where(m => m != null && m.UniqueCode == code).ToList();
        }

        public IList<HubClient> Get(Guid? tenantId = null, Guid? uid = null, string code = "")
        {
            ClearNullItem();
            return hubClients
                .WhereIf(tenantId.HasValue, m => m != null && m.TenantId == tenantId)
                .WhereIf(uid.HasValue, m => m != null && m.UserId == uid)
                .WhereIf(!code.IsNullOrEmpty(), m => m != null && m.UniqueCode == code)
                .ToList();
        }

        public void AddIfNotContain(HubClient client, bool replace = false)
        {
            ClearNullItem();
            if (hubClients.Any(m => m.ConnectionId == client.ConnectionId))
            {
                if (!replace) return;
                if (replace)
                {
                    var index = hubClients.FindIndex(m => m.ConnectionId == client.ConnectionId);
                    hubClients.RemoveAt(index);
                }
            }
            else
            {
                hubClients.Add(client);
            }
        }

        public void Remove(string connectionId)
        {
            ClearNullItem();
            var i = hubClients.FindIndex(m => m.ConnectionId == connectionId);
            if (i >= 0) hubClients.RemoveAt(i);
        }

        private void ClearNullItem()
        {
            try
            {
                var nullIndex = hubClients.FindIndex(m => m == null);
                while (nullIndex >= 0)
                {
                    hubClients.RemoveAt(nullIndex);
                    ClearNullItem();
                }
            }
            catch (Exception)
            { }


        }
    }
}
