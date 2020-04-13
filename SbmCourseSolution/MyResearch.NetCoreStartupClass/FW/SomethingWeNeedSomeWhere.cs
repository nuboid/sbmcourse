using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResearch.NetCoreStartupClass.FW
{
    public class SomethingWeNeedSomeWhere : ISomethingWeNeedSomewhere
    {
        public int DoingSomething(string param)
        {
            return 42;
        }
    }
}
