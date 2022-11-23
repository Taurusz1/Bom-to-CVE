using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ReadXML
{
    static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        string path = "C:\\Users\\Bazsó\\Desktop\\5.félév\\Témalab\\boms\\PetriNet.xml";

        doc.Load(args[0]);
        XmlNodeList list = doc.GetElementsByTagName("name");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i].InnerText.ToString());
        }
    }
   
}
