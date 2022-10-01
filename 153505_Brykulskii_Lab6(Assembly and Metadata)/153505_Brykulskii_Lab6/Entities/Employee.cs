namespace _153505_Brykulskii_Lab6.Entities
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public bool IsMale { get; set; }

        public Employee()
        {
            Name = string.Empty;
            Salary = 0;
            IsMale = true;
        }
        
        public Employee(string name, int salary, bool isMale)
        {
            Name = name;
            Salary = salary;
            IsMale = isMale;
        }

    }
}
