using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bom_to_CVE
{
    public class Post
    {
        
            public string Name { get; set; } = "N/A";

            public string Ecosystem { get; set; } = "NuGet";

        //Ebből még baj lesz
        public string ToJson()
        {
            return $"{{package: {{\"name\": \"{Name}\", \"ecosystem\" : \"{Ecosystem}\"}} }}";
        }
    }
}
