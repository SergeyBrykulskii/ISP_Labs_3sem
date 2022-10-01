namespace _153505_Brykulskii_Lab5.Domain.Entities
{
    public class RailwayStation
    {
        public string Name { get; set; }

        public LuggageCompartment LCom { get; set; }

        public int NumberOfPassengers { get; set; }

        public RailwayStation()
        {
            Name = "Default";
            LCom = new LuggageCompartment();
            NumberOfPassengers = 0;
        }

        public RailwayStation(string name, int numberOfPassengers, LuggageCompartment lCom)
        {
            Name = name;  
            NumberOfPassengers = numberOfPassengers;
            LCom = lCom;
        }
    }
}
