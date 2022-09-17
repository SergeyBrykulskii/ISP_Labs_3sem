class TypeOfWork
{
    public string Name { get; set; }
    public int Price { get; set; }
    public TypeOfWork(string name, int price)
    {
        Name = name;
        Price = price;
    }
    public TypeOfWork(string name)
    {
        Name = name;
        Price = 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
        {
            return false;
        }

        TypeOfWork typeOfWork = (TypeOfWork)obj;
        return Name == typeOfWork.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
