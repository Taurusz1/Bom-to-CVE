using System.Xml;
using Bom_to_CVE;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using MongoDB.Driver;

class ReadXML
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static Uri apiPath = new Uri("https://api.osv.dev/v1/query");
    static void Main(string[] args)
    {

        XmlDocument doc = new XmlDocument();
        doc.Load(args[0]);
        XmlNodeList nodeList = doc.GetElementsByTagName("name");
        List<string> parsedNames = parseNodeList(nodeList);
        //List<string> parsedNames = new List<string>();
        //parsedNames.Add("NuGet.Commands");
        /**Ha látni szeretnénk a kiolvasott csomagok neveit
foreach (XmlNode node in nodeList){
Console.WriteLine(node.InnerText.ToString());
}*/
        /**Ha látni szeretnénk a kiolvasott csomagok neveit
        foreach (string name in parsedNames)
        {
            Console.WriteLine(name);
        }*/

        var dbHelper = new MongoDBHelper();
        for (int i = 0; i < parsedNames.Count; i++)
        {
            var result = Requester.GetCVE(apiPath, parsedNames[i]);
            cveArray cve = JsonConvert.DeserializeObject<cveArray>(result);
            cve.dependecy = parsedNames[i];
            dbHelper.uploadData(cve);
        }
    }

   public static List<string> parseNodeList(XmlNodeList nodeList)
   {
        List<string> result = new List<string>();
        foreach (XmlNode node in nodeList)
        {
            if(node.InnerText.ToString() != "CycloneDX module for .NET" && node.InnerText.ToString() != "PetriTool")
            {
                var tmp = node.InnerText.ToString().Split(".");
                result.Add(tmp[1]);
            }
        }
        
        return result;
   }
    
    
    //nem biztos hogy jó a string param
    public static void printToFile(string result)
    {
        var json = JsonConvert.DeserializeObject(result);
        var path = "C:\\Users\\Bazsó\\Desktop\\5.félév\\Témalab\\boms";
        var fileName = "\\CVE.json";
        FileStream outputStream = File.Create(path + fileName);
        File.WriteAllText("CVE.json", json.ToString());
    }
    public static void printToStdout(string result)
    {
        var json = JsonConvert.DeserializeObject(result);
        Console.WriteLine(json.ToString());
    }
}
