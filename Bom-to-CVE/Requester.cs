using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml;

namespace Bom_to_CVE
{
    class Requester:HttpClient
    {
        public static string GetCVE(Uri url, string node)
        {
            using (var client = new HttpClient())
            {
                var newPost = new Package() { Name = node, Ecosystem = "NuGet" };
                var payload = new StringContent(newPost.ToJson());
                var response = client.PostAsync(url,payload).Result.Content.ReadAsStringAsync().Result;
                return response;
            }
        }
    }
}
