using Microsoft.Extensions.Configuration;
using System.IO;
public static class ConfigReader 
{ 
    private static IConfigurationRoot _config; 
    static ConfigReader() 
    { 
        _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("reqnroll.json", optional: false, reloadOnChange: true).Build(); 
    } 
    public static string GetBaseUrl() => _config["apiSettings:baseUrl"]; 

}