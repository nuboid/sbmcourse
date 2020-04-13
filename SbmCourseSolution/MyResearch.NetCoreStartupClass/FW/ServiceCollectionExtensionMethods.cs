using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResearch.NetCoreStartupClass.FW
{
    public static class ServiceCollectionExtensionMethods
    {
        public static void AddOurNeededStuff(this IServiceCollection services)
        {
            services.AddSingleton<ISomethingWeNeedSomewhere>(new SomethingWeNeedSomeWhere());
        }
    }
}
