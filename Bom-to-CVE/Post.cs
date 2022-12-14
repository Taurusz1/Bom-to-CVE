using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bom_to_CVE
{
    public class Package
    {
            public string Name { get; set; } = "N/A";
            public string Ecosystem { get; set; } = "NuGet";

        public string ToJson()
        {
            return $"{{package: {{\"name\": \"{Name}\", \"ecosystem\" : \"{Ecosystem}\"}} }}";
        }
    }
}
