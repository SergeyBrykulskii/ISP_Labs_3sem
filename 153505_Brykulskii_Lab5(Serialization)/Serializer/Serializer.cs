using _153505_Brykulskii_Lab5.Domain.Entities;

namespace Serializer
{
    class Serializer : _153505_Brykulskii_Lab5.Domain.Interfaces.ISerializer
    {
        public IEnumerable<RailwayStation> DeSerializeByLINQ(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RailwayStation> DeSerializeJSON(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RailwayStation> DeSerializeXML(string fileName)
        {
            throw new NotImplementedException();
        }

        public void SerializeByLINQ(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            throw new NotImplementedException();
        }

        public void SerializeJSON(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            throw new NotImplementedException();
        }

        public void SerializeXML(IEnumerable<RailwayStation> ListOfRailwayStations, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
