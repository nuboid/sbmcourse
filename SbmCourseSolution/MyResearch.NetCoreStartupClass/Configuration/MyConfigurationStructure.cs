using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResearch.NetCoreStartupClass.Configuration
{
    public class MyConfigurationStructure
    {
        public String Field1 { get; set; } 
        public String Field2 { get; set; }

        public String Field3 { get; set; } = "default";
    }
}
