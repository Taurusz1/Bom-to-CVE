using MongoDB.Driver;

namespace Bom_to_CVE
{
    public class MongoDBHelper
    {
        string conn = "mongodb://localhost:27017";
        string dbName = "CVE_DB";
        string collectionName = "CVE_Array_Experiment";

        public void uploadData(cveArray cveArr)
        {
            var client = new MongoClient(conn);
            var db = client.GetDatabase(dbName);
            var collection = db.GetCollection<cveArray>(collectionName);
            collection.InsertOne(cveArr);
        }       
    }
}
