using Entity.Concrete;
using MongoDB.Driver;

namespace DataAccess.Concrete
{
    public class ReadingsDbContext:IDisposable
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        public IMongoCollection<Reading> Collection { get; private set; }

        public ReadingsDbContext()
        {
            _client = new MongoClient("mongodb://host.docker.internal/");//Değiştir
            _db = _client.GetDatabase("Readings");
            Collection = _db.GetCollection<Reading>("Reading");
        }

        public void Dispose()
        {
            
        }
    }
}