using System.Xml;
using Bom_to_CVE;
using Newtonsoft.Json;
//signed commit test
class Controller
{
    private static Uri apiPath = new Uri("https://api.osv.dev/v1/query");
    private const String writeToPcPath = "C:\\Users\\Bazsó\\Desktop\\5.félév\\Témalab\\boms";
    private const String fileName = "\\asdasd.json";

    private const string ecoSystem = "Nuget";
    
    static void Main(string[] args)
    {
        //queryAndUpload(ReadXML(args[0]));
        List<string> parsedNames = new List<string>();
        List<string> parsedEcoSystems = new List<string>();
        parsedNames.Add("NuGet.Commands");
        queryAndUpload(parsedNames, parsedEcoSystems);
    }
    public static (List<string>, List<string>) ReadXML(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodeList = doc.GetElementsByTagName("name");
        /**Ha látni szeretnénk a kiolvasott csomagok neveit nodeból
        foreach (XmlNode node in nodeList){
            Console.WriteLine(node.InnerText.ToString());
        }*/
        return parseNodeList(nodeList);
    }
    public static (List<string>, List<string>) parseNodeList(XmlNodeList nodeList)
    {
        List<string> parsedNames = new List<string>();
        List<string> parsedEcoSystems = new List<string>();
        foreach (XmlNode node in nodeList)
        {
            //ezt is megcsinálni általánosra
            if(node.InnerText.ToString() != "CycloneDX module for .NET" && node.InnerText.ToString() != "PetriTool")
            {
                var tmp = node.InnerText.ToString().Split(".");
                parsedEcoSystems.Add(tmp[0]);
                parsedNames.Add(tmp[1]);
            }
        }
        /**Ha látni szeretnénk a kiolvasott csomagok neveit stringből
        foreach (string name in parsedNames)
        {
            Console.WriteLine(name);
        }*/
        return (parsedNames, parsedEcoSystems);
    }
    public static void queryAndUpload(List<string> parsedNames, List<string> parsedEcoSystems)
    {
        //Todo megcsinálni szépre
        if(parsedNames.Count != parsedEcoSystems.Count)
        {
            throw new Exception("Nem egyeznek a tömb hosszok");
        }
        //TODO check if db upload works
        var dbHelper = new MongoDBHelper();
        for(int i = 0; i < parsedNames.Count; i++)// string name in parsedNames)
        {
            var result = Http_Messaging_Service.GetCVE(apiPath, parsedNames[i], parsedEcoSystems[i]);
            //TODO null check
            cveArray cve = JsonConvert.DeserializeObject<cveArray>(result);
            cve.dependecy = parsedNames[i];
            printToFile(result, writeToPcPath, fileName);
            //dbHelper.uploadData(cve);
        }
    }
    
    public static void printToFile(string result, string path, string fileName)
    {
        var json = JsonConvert.DeserializeObject(result); 
        File.WriteAllText(path+fileName, json.ToString());
    }
    public static void printToConsole(string result)
    {
        var json = JsonConvert.DeserializeObject(result);
        Console.WriteLine(json.ToString());
    }
}
