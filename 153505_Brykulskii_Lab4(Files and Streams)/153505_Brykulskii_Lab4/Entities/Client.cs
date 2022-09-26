namespace _153505_Brykulskii_Lab4.Entities
{
    class Client
    {
        public string? Name { get; set; }

        public bool? IsVip { get; set; }
        
        public int? Budget { get; set; }

        public Client()
        {
            Name = null;
            IsVip = null;
            Budget = null;
        }
        public Client(string name, bool isVip, int budget)
        {
            Name = name;
            IsVip = isVip;
            Budget = budget;
        }
        public Client(string lineReadedFromFile)
        {
            string[] data = lineReadedFromFile.Split(' ');
            Name = data[0];
            IsVip = bool.Parse(data[1]);
            Budget = int.Parse(data[2]);
        }
        public override string ToString()
        {
            return $"{Name} {IsVip} {Budget}";
        }
    }
}
