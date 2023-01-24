public class cveArray
{
    public Vuln[] vulns { get; set; }
    public string dependecy { get; set; }
}

public class Vuln
{

    public string id { get; set; }
    public string summary { get; set; }
    public string details { get; set; }
    public string[] aliases { get; set; }
    public DateTime modified { get; set; }
    public DateTime published { get; set; }
    public Database_Specific database_specific { get; set; }
    public Reference[] references { get; set; }
    public Affected[] affected { get; set; }
    public string schema_version { get; set; }
    public Severity[] severity { get; set; }
}

public class Database_Specific
{
    public object[] cwe_ids { get; set; }
    public string severity { get; set; }
    public bool github_reviewed { get; set; }
}

public class Reference
{
    public string type { get; set; }
    public string url { get; set; }
}

public class Affected
{
    public Package package { get; set; }
    public Range[] ranges { get; set; }
    public string[] versions { get; set; }
    public Database_Specific1 database_specific { get; set; }
}

public class Package
{
    public string name { get; set; }
    public string ecosystem { get; set; }
    public string purl { get; set; }
}

public class Database_Specific1
{
    public string source { get; set; }
}

public class Range
{
    public string type { get; set; }
    public Event[] events { get; set; }
}

public class Event
{
    public string introduced { get; set; }
    public string _fixed { get; set; }
}

public class Severity
{
    public string type { get; set; }
    public string score { get; set; }
}
