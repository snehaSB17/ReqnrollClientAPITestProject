using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollClientAPITestProject.Support
{
    public class JsonFilesRepository
    {
        private const string Root = "../../../Utilities/"; // Adjust path as necessary
        public Dictionary<string, string> Files { get; } = new Dictionary<string, string>();

        public JsonFilesRepository()
        {
            // Load all JSON files in the specified directory
            foreach (var file in Directory.GetFiles(Root, "*.json"))
            {
                var fileName = Path.GetFileName(file);
                var contents = File.ReadAllText(file);
                Files.Add(fileName, contents);
            }
        }

        public T GetJsonData<T>(string fileName)
        {
            if (Files.ContainsKey(fileName))
            {
                return JsonConvert.DeserializeObject<T>(Files[fileName]);
            }
            throw new FileNotFoundException($"The file {fileName} was not found in the repository.");
        }
    }
}
