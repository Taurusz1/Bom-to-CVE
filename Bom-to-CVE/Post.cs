namespace Bom_to_CVE
{
    public class Package
    {
        public string Name { get; set; } = "N/A";
        public string Ecosystem { get; set; } = "N/A";

        public string ToJson()
        {
            return $"{{package: {{\"name\": \"{Name}\", \"ecosystem\" : \"{Ecosystem}\"}} }}";
        }
    }
}
