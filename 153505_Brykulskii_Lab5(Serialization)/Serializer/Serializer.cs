using _153505_Brykulskii_Lab5.Domain.Entities;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _153505_Brykulskii_Lab5.Serializer
{
    public class Serializer : Domain.Interfaces.ISerializer
    {
        public void SerializeJSON(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {     
             string json = JsonSerializer.Serialize(ListOfRailwayStations);
             File.WriteAllText(fileName, json);
        }

        public void SerializeByLINQ(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            var xml = new XElement("RailwayStations",
                from railwayStation in ListOfRailwayStations
                select new XElement("RailwayStation",
                    new XElement("Name", railwayStation.Name),
                    new XElement("NumberOfPassengers", railwayStation.NumberOfPassengers),
                    new XElement("LuggageCompartment",
                        new XElement("Capacity", railwayStation.LCom.Capacity),
                        new XElement("IsFree", railwayStation.LCom.IsFree)
                    )
                )
            );
            xml.Save(fileName);
        }

        public void SerializeXML(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            XmlSerializer formatter = new (typeof(List<RailwayStation>));
            using FileStream fs = new(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(fs, ListOfRailwayStations);
        }

        public IEnumerable<RailwayStation> DeSerializeJSON(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<IEnumerable<RailwayStation>>(json);
        }

        public IEnumerable<RailwayStation> DeSerializeByLINQ(string fileName)
        {
            var xml = XDocument.Load(fileName);
            var railwayStations = from railwayStation in xml.Element("RailwayStations").Elements("RailwayStation")
                                  select new RailwayStation
                                  {
                                      Name = railwayStation.Element("Name").Value,
                                      NumberOfPassengers = int.Parse(railwayStation.Element("NumberOfPassengers").Value),
                                      LCom = new LuggageCompartment
                                      {
                                          Capacity = int.Parse(railwayStation.Element("LuggageCompartment").Element("Capacity").Value),
                                          IsFree = bool.Parse(railwayStation.Element("LuggageCompartment").Element("IsFree").Value)
                                      }
                                  };
            return railwayStations;
        }

        public IEnumerable<RailwayStation> DeSerializeXML(string fileName)
        {
            XmlSerializer formatter = new(typeof(List<RailwayStation>));
            using FileStream fs = new(fileName, FileMode.OpenOrCreate);
            return formatter.Deserialize(fs) as IEnumerable<RailwayStation>;
        }

    }
}
