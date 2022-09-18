namespace _153505_Brykulskii_Lab3.Entities
{
    class Job
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Job(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public Job(string name)
        {
            Name = name;
            Price = 0;
        }

        public override bool Equals(object? obj)
        {
            Job? job = obj as Job;
            
            if (job == null)
            {
                return false;
            }
            
            return Name == job.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
