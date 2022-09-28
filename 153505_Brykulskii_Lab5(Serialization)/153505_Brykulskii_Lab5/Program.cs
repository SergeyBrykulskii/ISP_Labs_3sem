using _153505_Brykulskii_Lab5.Domain.Entities;
using _153505_Brykulskii_Lab5.Serializer;

List<RailwayStation> listOfRailwayStations = new();

listOfRailwayStations.Add(new RailwayStation("Kyiv:"));
listOfRailwayStations.Add(new RailwayStation("Lviv:"));
listOfRailwayStations.Add(new RailwayStation("Kharkiv:"));

var serializer = new Serializer();
