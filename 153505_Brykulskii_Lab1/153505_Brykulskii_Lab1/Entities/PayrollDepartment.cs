using System.Xml.Linq;

class PayrollDepartment
{
    private MyCustomCollections<Worker> workers;
    private MyCustomCollections<TypeOfWork> typesOfWorks;
    public int TotalSalary { get; private set; }

    public delegate void AddedWorkForWorkerHandler(string message);
    public event AddedWorkForWorkerHandler? AddedWork;

    public event EventHandler<ChengesOfListsEventArgs> ChengesOfLists;

    
    public PayrollDepartment()
    {
        workers = new MyCustomCollections<Worker>();
        typesOfWorks = new MyCustomCollections<TypeOfWork>();
        TotalSalary = 0;
    }
    
    public void AddWorker(string name, string surname)
    {
        workers.Add(new Worker(name, surname));
        ChengesOfLists?.Invoke(this, new ChengesOfListsEventArgs($"Worker {name} {surname} was added"));
    }

    public void AddTypeOfWork(string jobTitle, int price)
    {
        typesOfWorks.Add(new TypeOfWork(jobTitle, price));
        ChengesOfLists?.Invoke(this, new ChengesOfListsEventArgs($"Type of work \"{jobTitle}\" was added"));
    }

    public void AddWorkThatWorkerDid(string nameOfWorker, string surnameOfWorker, string typeOfWorkThatWorkerDid)
    {
        int numberOfWorkers = 0;
        int numberOfTypeOfWork = 0;
        workers.Reset();

        while (numberOfWorkers != workers.Count)
        {
            Worker currentWorker = workers.Current();
            
            if (currentWorker.Name == nameOfWorker && currentWorker.Surname == surnameOfWorker)
            {
                typesOfWorks.Reset();
                
                while (numberOfTypeOfWork != typesOfWorks.Count)
                {
                    TypeOfWork currentTypeOfWork = typesOfWorks.Current();
                    
                    if (currentTypeOfWork.Name == typeOfWorkThatWorkerDid)
                    {
                        AddedWork?.Invoke($"To {currentWorker.Name} {currentWorker.Surname} was added work {currentTypeOfWork.Name} with price {currentTypeOfWork.Price}");
                        currentWorker.AddWork(currentTypeOfWork);
                        TotalSalary += currentTypeOfWork.Price;
                        return;
                    }
                    
                    numberOfTypeOfWork++;
                    typesOfWorks.Next();
                }
                Console.WriteLine($"Type of work \"{typeOfWorkThatWorkerDid}\" not found");
                return;
            }
            
            numberOfWorkers++;
            workers.Next();
        }
        Console.WriteLine($"Worker {nameOfWorker} {surnameOfWorker} not found");
        return;
    }
    
    public int GetTotalSalary()
    {
        return TotalSalary;
    }

    public void GetWorkerSalary(string name, string surname)
    {
        int numberOfWorkers = 0;
        workers.Reset();
        while (workers.Current() != null)
        {
            Worker currentWorker = workers.Current();
            if (currentWorker.Name == name && currentWorker.Surname == surname)
            {
                Console.WriteLine($"{name} {surname} salary: {currentWorker.Salary}");
                return;
            }
            numberOfWorkers++;
            if (numberOfWorkers == workers.Count)
            {
                Console.WriteLine($"Worker {name} {surname} not found");
                return;
            }
            workers.Next();
        }
    }
    
    public string GetTypeOfFirstCollection()
    {
        return workers.GetType();
    }
    public string GetTypeOfSecondCollection()
    {
        return typesOfWorks.GetType();
    }
}

