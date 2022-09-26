using _153505_Brykulskii_Lab4.Entities;

namespace _153505_Brykulskii_Lab4.FileClasses
{
    class FileService<T> : IFileService<T>
    {
        public IEnumerable<T> ReadFile(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    yield return (T)Activator.CreateInstance(typeof(T), reader.ReadString());
                }
            }

        }

        public void SaveData(IEnumerable<T> data, string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var item in data)
                {
                    writer.Write(item.ToString());
                }
            }
        }
    }
}
