using _153505_Brykulskii_Lab6.Entities;
using System.Reflection;

List<Employee> listOfEmployee = new();

listOfEmployee.Add(new Employee("Oleg", 666, true));
listOfEmployee.Add(new Employee("Anna", 99999, false));
listOfEmployee.Add(new Employee("II", 1234567, true));
listOfEmployee.Add(new Employee("Timofei", 9, true));
listOfEmployee.Add(new Employee("Sasha", 43, true));

Assembly asm = Assembly.LoadFrom("FileServiceLib.dll");

Type FileService = asm.GetType("FileServiceLib" + "." + "FileService`1").MakeGenericType(typeof(Employee));


MethodInfo? SaveDataToFile = FileService.GetMethod("SaveData");
MethodInfo? LoadDataFromFile = FileService.GetMethod("ReadFile");

SaveDataToFile.Invoke(Activator.CreateInstance(FileService), new object[] { listOfEmployee, "Employee.json" });
var listOfEmployeeFromFile = LoadDataFromFile.Invoke(Activator.CreateInstance(FileService), new object[] {"Employee.json" });

foreach (var item in (IEnumerable<Employee>)listOfEmployeeFromFile)
{
    Console.WriteLine(item);
}


