using _153505_Brykulskii_Lab4.Entities;
using _153505_Brykulskii_Lab4.FileClasses;

string path = "client.txt", newPath = "newClient.txt";

List<Client> Clients = new(), ClientsReadedFromFile;

FileService<Client> fileService = new();

Clients.Add(new Client("Pavel", false, 600));
Clients.Add(new Client("Vadim", false, 666));
Clients.Add(new Client("Timofei", false, 42));
Clients.Add(new Client("IgorIvanovich", true, 9999999));

fileService.SaveData(Clients, path);

File.Delete(newPath);
File.Move(path, newPath);

ClientsReadedFromFile = fileService.ReadFile(newPath).ToList();

ClientsReadedFromFile = ClientsReadedFromFile.OrderBy(obj => obj, new MyCustomComparer()).ToList();

foreach (var item in Clients)
{
    Console.WriteLine(item);
}

Console.WriteLine();

foreach (var item in ClientsReadedFromFile)
{
    Console.WriteLine(item);
}

Clients = Clients.OrderBy(obj => obj.Budget).ToList();

Console.WriteLine();

foreach (var item in Clients)
{
    Console.WriteLine(item);
}