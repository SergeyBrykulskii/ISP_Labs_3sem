namespace _153505_Brykulskii_Lab5.Domain.Entities
{
    [Serializable]
    public class RailwayStation
    {
        public string Name { get; set; }

        public RailwayStation(string name)
        {
            Name = name;
        }
    }
}
