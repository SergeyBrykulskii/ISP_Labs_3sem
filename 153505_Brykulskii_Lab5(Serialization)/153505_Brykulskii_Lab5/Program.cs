using _153505_Brykulskii_Lab5.Domain.Entities;
using _153505_Brykulskii_Lab5.Serializer;

List<RailwayStation> listOfRailwayStations = new(), listOfRailwayStationsFromFile;

listOfRailwayStations.Add(new RailwayStation("Kyiv", 150, new LuggageCompartment(100, true)));
listOfRailwayStations.Add(new RailwayStation("Lviv", 200, new LuggageCompartment(150, false)));
listOfRailwayStations.Add(new RailwayStation("Kharkiv", 300, new LuggageCompartment(200, true)));

var serializer = new Serializer();

serializer.SerializeJSON(listOfRailwayStations, "RailwayStation.json");

listOfRailwayStationsFromFile = serializer.DeSerializeJSON("RailwayStation.json").ToList<RailwayStation>();

foreach (var item in listOfRailwayStationsFromFile)
{
    Console.WriteLine($"Name: {item.Name}, Number of passengers: {item.NumberOfPassengers}, " +
        $"Luggage compartment capacity: {item.LCom.Capacity}, Luggage compartment is free: {item.LCom.IsFree}");
}

serializer.SerializeByLINQ(listOfRailwayStations, "RailwayStation.xml");