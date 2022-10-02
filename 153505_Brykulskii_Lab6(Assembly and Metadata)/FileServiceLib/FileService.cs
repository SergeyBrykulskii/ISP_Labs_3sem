using _153505_Brykulskii_Lab6.Interfaces;
using System.Text.Json;

namespace FileServiceLib
{
    internal class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<IEnumerable<T>>(json);
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, json);  
        }
    }
}
