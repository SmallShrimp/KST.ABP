using System;
using Volo.Abp.Modularity;
using Volo.Abp.Json;
using Volo.Abp.Security;

namespace KST.ABP.SignalR
{

    [DependsOn(typeof(AbpJsonModule), typeof(AbpSecurityModule))]
    public class KSTABPSignalRModule : AbpModule
    {

    }
}
