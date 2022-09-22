using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Principal;

namespace _153505_Brykulskii_Lab3.Entities
{
    class PayrollDepartment
    {
        public delegate void AddedWorkForWorkerHandler(string message);

        public event EventHandler<PayrollDepartmentEventArgs> ChengesOfLists;
        
        private List<Worker> workers;
        private Dictionary<string, Job> jobs;
        public int TotatalSalary { get; private set; }
        
        public PayrollDepartment()
        {
            workers = new();
            jobs = new();
            TotatalSalary = 0;
        }

        public void AddWorker(string name, string surname)
        {
            Worker newWorker = new (name, surname);
            
            if (workers.Contains(newWorker))
            {
                Console.WriteLine("Worker already exists");
            }
            else
            {
                workers.Add(newWorker);
                ChengesOfLists?.Invoke(this, new PayrollDepartmentEventArgs($"Worker {name} {surname} was added"));
            }
        }

        public void AddJob(string name, int price)
        {
            Job newJob = new (name, price);

            if (jobs.ContainsKey(name))
            {
                Console.WriteLine("Job already exists");
            }
            else
            {
                jobs.Add(name, newJob);
                ChengesOfLists?.Invoke(this, new PayrollDepartmentEventArgs($"Type of work \"{name}\" was added"));
            }
        }

        public void AddJobToWorker(string name, string surname, string jobName)
        {
            if (workers == null)
            {
                Console.WriteLine("There are no workers");
                return;
            }
            Worker worker = workers.Find(w => w.Name == name && w.Surname == surname);
            Job job = jobs[jobName];

            if (worker == null)
            {
                Console.WriteLine("Worker not found");
                return;
            }
            if (job == null)
            {
                Console.WriteLine("Job not found");
                return;
            }

            ChengesOfLists?.Invoke(this, new PayrollDepartmentEventArgs($"Type of work \"{name}\" was added to worker {name} {surname}"));
            worker.AddJob(job);
            TotatalSalary += job.Price;
        }

        public List<Job> GetJobsListSortedByPrice()
        {
            return (from jobs in jobs.Values
                    orderby jobs.Price
                    select jobs).ToList();
        }

        public int GetTotalSalary()
        {
            return workers.Sum(w => w.Salary);
        }

        public int GetTotalSalaryForWorker(string name, string surname)
        {
            Worker worker = workers.Find(w => w.Name == name && w.Surname == surname);
            if (worker == null)
            {
                Console.WriteLine("Worker not found");
                return 0;
            }
            return worker.Salary;
        }

        public string? GetNameOfTheWorkerWithTheHighestSalary()
        {
            if (workers == null)
            {
                throw new Exception("There are no workers");
            }
            return (from worker in workers
                   orderby worker.Salary descending
                   select worker.Name + " " + worker.Surname).ToString();
        }

        public int GetNumberOfWorkersThatGetMoreThan(int salary)
        {
            return workers.Count(w => w.Salary > salary);
        }
        
        
        public List<ListSelaryForworker> GetListSalaryForWorker(string name, string surname)
        {
            Worker? worker = workers.Find(w => w.Name == name && w.Surname == surname);
            while (worker == null)
            {
                Console.WriteLine("Worker not found");
                Console.WriteLine("Enter name of worker");
                name = Console.ReadLine();
                Console.WriteLine("Enter surname of worker");
                surname = Console.ReadLine();
                worker = workers.Find(w => w.Name == name && w.Surname == surname);
            }
            var list = from jobs in worker.jobThatWorkerDid
                     group jobs by jobs.TitleOfJob;
            
            var ls = new List<ListSelaryForworker>();

            foreach (var item in list)
            {
                ls.Add(new ListSelaryForworker(item.Key, (from it in item select it.Price).ToList()));
            }

            return ls;
        }
    }
    class ListSelaryForworker
    {
        public string TitleOfJob { get; set; }
        public List<int> Salaries { get; set; }

        public ListSelaryForworker(string titleOfJob, List<int> salaries)
        {
            TitleOfJob = titleOfJob;
            Salaries = salaries.ToList();
        }

        public override string ToString()
        {
            return $"Title of job: {TitleOfJob}, Salaries: {string.Join(", ", Salaries)}";
        }
    }
}

