class Worker
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Salary { get; set; }

    public MyCustomCollections<TypeOfWork> worksThatWorkerDid;
    public Worker()
    {
        Name = "";
        Surname = "";
        Salary = 0;
        worksThatWorkerDid = new();
    }
    public Worker(string name, string surname)
    {
        Name = name;
        Surname = surname;
        worksThatWorkerDid = new();
        Salary = 0;
    }

    public void AddWork(TypeOfWork work)
    {
        worksThatWorkerDid.Add(work);
        Salary += work.Price;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
        {
            return false;
        }

        Worker worker = (Worker)obj;
        return Name == worker.Name && Surname == worker.Surname;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Surname.GetHashCode();
    }
}
