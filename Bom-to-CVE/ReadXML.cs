using System.Xml;
using Bom_to_CVE;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Collections;

class ReadXML
{
    private static readonly JsonSerializerOptions _options =
    new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    static void Main(string[] args)
    {

        XmlDocument doc = new XmlDocument();
        doc.Load(args[0]);
        XmlNodeList list = doc.GetElementsByTagName("name");
        /**for (int i = 0; i < list.Count; i++){
            Console.WriteLine(list[i].InnerText.ToString());
        }*/


        var apiPath = new Uri("https://api.osv.dev/v1/query");
        var result = Requester.GetCVE(apiPath);
        var json = JsonConvert.DeserializeObject(result);
        //Console.WriteLine(json.ToString());

        /**
        var path = "C:\\Users\\Bazsó\\Desktop\\5.félév\\Témalab\\boms";
        var fileName = "\\CVE.json";
        FileStream outputStream = File.Create(path + fileName);
        File.WriteAllText("CVE.json", json.ToString());
        */

        cveArray cve = JsonConvert.DeserializeObject<cveArray>(result);
        //for (int i = 0; i < cve.vulns.Length; i++)
        //{
        Console.WriteLine(cve.vulns[0].severity[0].score);
        //Console.WriteLine(cve.vulns[0].id);
        //Console.WriteLine();
        //Console.WriteLine(cve.vulns[0].summary);
        //Console.WriteLine(cve.vulns[0].affected);
        //Console.WriteLine(cve.vulns[0].modified);
        //Console.WriteLine(cve.vulns[0].aliases);
        //Console.WriteLine(cve.vulns[0].database_specific);
        //Console.WriteLine(cve.vulns[0].details);
        //}
    }
}
