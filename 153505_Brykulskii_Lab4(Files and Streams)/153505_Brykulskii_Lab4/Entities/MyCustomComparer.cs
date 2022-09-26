namespace _153505_Brykulskii_Lab4.Entities
{
    class MyCustomComparer : IComparer<Client>
    {
        public int Compare(Client? x, Client? y)
        {
            if (x is null || y is null)
            {
                return 0;
            }
            if (x is null)
            {
                return -1;
            }
            if (y is null)
            {
                return 1;
            }
            
            return x.Name.CompareTo(y.Name);
        }
    }
}
