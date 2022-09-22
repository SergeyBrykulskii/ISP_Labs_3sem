using _153505_Brykulskii_Lab3.Entities;

PayrollDepartment payrollDepartment = new();

payrollDepartment.AddWorker("Pavel", "Schirov");
payrollDepartment.AddWorker("Timofei", "Vlasenko");
payrollDepartment.AddWorker("Vadim", "Zur");

payrollDepartment.AddJob("Programmer", 1000);
payrollDepartment.AddJob("Manager", 2000);
payrollDepartment.AddJob("Cleaner", 500);

payrollDepartment.AddJobToWorker("Pavel", "Schirov", "Programmer");
payrollDepartment.AddJobToWorker("Pavel", "Schirov", "Programmer");
payrollDepartment.AddJobToWorker("Pavel", "Schirov", "Manager");
payrollDepartment.AddJobToWorker("Pavel", "Schirov", "Manager");
payrollDepartment.AddJobToWorker("Pavel", "Schirov", "Manager");

var list = payrollDepartment.GetListSalaryForWorker("Pavel", "Schirov");

foreach (var item in list)
{
    Console.WriteLine(item);
}




