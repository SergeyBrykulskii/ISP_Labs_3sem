namespace _153505_Brykulskii_Lab5.Domain.Entities
{
    [Serializable]
    public class RailwayStation
    {
        public string Name { get; set; }

        public LuggageCompartment LCom { get; set; }

        public int NumberOfPassengers { get; set; }


        public RailwayStation(string name, int numberOfPassengers, LuggageCompartment lCom)
        {
            Name = name;  
            NumberOfPassengers = numberOfPassengers;
            LCom = lCom;
        }
    }
}
