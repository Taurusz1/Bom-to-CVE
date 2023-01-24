using MongoDB.Driver;

namespace Bom_to_CVE
{
    public class MongoDBHelper
    {
        public string Conn { get; set; } = "mongodb://localhost:27017";
        public string DBName { get; set; } = "CVE_DB";
        public string CollectionName { get; set; } = "CVE_Array_Experiment";
        public MongoDBHelper(string conn, string dbName, string collectionName)
        {
            Conn = conn;
            DBName = dbName;
            CollectionName = collectionName;
        }
        public MongoDBHelper() { }

        public void uploadData(cveArray cveArr)
        {
            var client = new MongoClient(Conn);
            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<cveArray>(CollectionName);
            collection.InsertOne(cveArr);
        }
    }
}
