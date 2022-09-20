using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Principal;

namespace _153505_Brykulskii_Lab3.Entities
{
    class PayrollDepartment
    {
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
            return TotatalSalary;
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

        public string GetNameOfTheWorkerWithTheHighestSalary()
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
    }
}
