namespace Bom_to_CVE
{
    class Http_Messaging_Service:HttpClient
    {
        public static string GetCVE(Uri url, string dependencyName, string ecoSystem)
        {
            using (var client = new HttpClient())
            {
                var newPost = new Package() { Name = dependencyName, Ecosystem = ecoSystem};
                var payload = new StringContent(newPost.ToJson());
                var response = client.PostAsync(url,payload).Result.Content.ReadAsStringAsync().Result;
                return response;
            }
        }
    }
}
