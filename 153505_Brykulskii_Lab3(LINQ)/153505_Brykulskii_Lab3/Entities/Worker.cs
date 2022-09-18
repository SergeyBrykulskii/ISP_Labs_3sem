namespace _153505_Brykulskii_Lab3.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }

        public List<Job> jobThatWorkerDid;
        public Worker()
        {
            Name = "";
            Surname = "";
            Salary = 0;
            jobThatWorkerDid = new();
        }
        public Worker(string name, string surname)
        {
            Name = name;
            Surname = surname;
            jobThatWorkerDid = new();
            Salary = 0;
        }
        
        public void AddWork(Job job)
        {
            jobThatWorkerDid.Add(job);
            Salary += job.Price;
        }

        public override bool Equals(object? obj)
        {
            Worker? worker = obj as Worker;

            if (worker == null)
            {
                return false;
            }

            return Name == worker.Name && Surname == worker.Surname;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode();
        }
    }
}
