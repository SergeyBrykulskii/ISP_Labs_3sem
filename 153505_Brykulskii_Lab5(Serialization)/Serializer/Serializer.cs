using _153505_Brykulskii_Lab5.Domain.Entities;
using System.Text.Json;

namespace _153505_Brykulskii_Lab5.Serializer
{
    public class Serializer : Domain.Interfaces.ISerializer
    {
        public void SerializeJSON(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            foreach(var item in ListOfRailwayStations)
            {
                var json = JsonSerializer.Serialize(item);
                File.AppendAllText(fileName, json);
            }
        }

        public void SerializeByLINQ(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            throw new NotImplementedException();
        }

        public void SerializeXML(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RailwayStation> DeSerializeJSON(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var ListOfRailwayStations = JsonSerializer.Deserialize<IEnumerable<RailwayStation>>(json);
            return ListOfRailwayStations;
        }

        public IEnumerable<RailwayStation> DeSerializeByLINQ(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RailwayStation> DeSerializeXML(string fileName)
        {
            throw new NotImplementedException();
        }

    }
}
