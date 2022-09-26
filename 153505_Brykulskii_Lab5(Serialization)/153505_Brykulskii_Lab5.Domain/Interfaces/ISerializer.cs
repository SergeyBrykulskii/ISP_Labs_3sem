using _153505_Brykulskii_Lab5.Domain.Entities;

namespace _153505_Brykulskii_Lab5.Domain.Interfaces
{
    public interface ISerializer
    {
        IEnumerable<RailwayStation> DeSerializeByLINQ(string fileName);
        IEnumerable<RailwayStation> DeSerializeXML(string fileName);
        IEnumerable<RailwayStation> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName);
        void SerializeXML(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName);
        void SerializeJSON(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName);
    }
}
