namespace _153505_Brykulskii_Lab3.Entities
{
    class Job
    {
        public string TitleOfJob { get; set; }
        public int Price { get; set; }
        public Job(string name, int price)
        {
            TitleOfJob = name;
            Price = price;
        }
        public Job(string name)
        {
            TitleOfJob = name;
            Price = 0;
        }

        public override bool Equals(object? obj)
        {
            Job? job = obj as Job;
            
            if (job == null)
            {
                return false;
            }
            
            return TitleOfJob == job.TitleOfJob;
        }

        public override int GetHashCode()
        {
            return TitleOfJob.GetHashCode();
        }

        public override string ToString()
        {
            return $"Title of job: {TitleOfJob}, Price: {Price}";
        }
    }
}
