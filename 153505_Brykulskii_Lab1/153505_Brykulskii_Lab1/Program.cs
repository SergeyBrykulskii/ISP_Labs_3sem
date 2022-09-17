/*MyCustomCollections<int> intList = new();

Console.WriteLine(intList.GetType());

intList.Add(1);
intList.Add(2);
intList.Add(3);

Console.WriteLine($"List of integers: {intList[0]}, {intList[1]}, {intList[2]}");

Console.WriteLine($"Current in list of integers: {intList.Current()}");
intList.Next();
Console.WriteLine($"Current in list of integers: {intList.Current()}");
intList.Next();
Console.WriteLine($"Current in list of integers: {intList.Current()}");
intList.Reset();
Console.WriteLine($"Current in list of integers: {intList.Current()}");

Console.WriteLine($"{intList.Contains(1)}");
Console.WriteLine($"{intList.Contains(2)}");
Console.WriteLine($"{intList.Contains(3)}");
Console.WriteLine($"{intList.Contains(4)}");


intList.Remove(1);

Console.WriteLine($"{intList.Contains(1)}");
Console.WriteLine($"List of integers: {intList[0]}, {intList[1]}");

intList.Add(1);

intList.Remove(2);
Console.WriteLine($"{intList.Contains(2)}");
Console.WriteLine($"List of integers: {intList[0]}, {intList[1]}");
intList.Add(2);

intList.Remove(3);
Console.WriteLine($"{intList.Contains(3)}");
Console.WriteLine($"List of integers: {intList[0]}, {intList[1]}");
intList.Add(3);

intList.RemoveCurrent();
Console.WriteLine($"List of integers: {intList[0]}, {intList[1]}");

Console.WriteLine($"Current in list of integers: {intList.Current()}");

*/

PayrollDepartment dep1 = new();
Journal journal1 = new(dep1);
//dep1.AddedWork += DisplayMessage;

dep1.AddWorker("Ivan", "Ivanov");
dep1.AddWorker("Petr", "Petrov");
dep1.AddWorker("Sidor", "Sidorov");


dep1.AddTypeOfWork("Cleaner", 100);
dep1.AddTypeOfWork("Manager", 500);
dep1.AddTypeOfWork("Programmer", 1000);


journal1.ShowEvents();


dep1.AddWorkThatWorkerDid("Ivan", "Ivanov", "Claner");
dep1.AddWorkThatWorkerDid("Petr", "Petrov", "Manager");
dep1.AddWorkThatWorkerDid("Sidor", "Sidorov", "Programmer");
dep1.AddWorkThatWorkerDid("Sidor", "Sidorov", "Manager");

Console.WriteLine($"Total salary: {dep1.GetTotalSalary()}");

dep1.GetWorkerSalary("Ivan", "Ivanov");
dep1.GetWorkerSalary("Petr", "Petrov");
dep1.GetWorkerSalary("Sidor", "Sidorov");
dep1.GetWorkerSalary("Sior", "Siorov");


void DisplayMessage(string message) => Console.WriteLine(message);

/*MyCustomCollections<int> ls = new();

ls.Add(1);
ls.Add(2);

foreach (var item in ls)
{
    Console.WriteLine(item);
}

try
{
    ls[3] = 3;
}
catch (IndexOutOfRangeException expr)
{
    Console.WriteLine(expr.Message);
}

try
{
    ls.Remove(3);
}
catch (RemoveException expr)
{
    Console.WriteLine(expr.Message);
}
*/