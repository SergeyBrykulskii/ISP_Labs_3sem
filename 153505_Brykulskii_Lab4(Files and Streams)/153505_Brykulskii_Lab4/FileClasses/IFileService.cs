namespace _153505_Brykulskii_Lab4.FileClasses
{
    interface IFileService<T>
    {
        IEnumerable<T> ReadFile(string path);
        void SaveData(IEnumerable<T> data, string path);
    }
}
