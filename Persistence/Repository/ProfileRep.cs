using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Persistence.Context;

namespace SimpleBot.Persistence.Repository
{
    public class ProfileRep : Common.Repository
    {
        public ProfileRep()
            : base("message") { }

        public void Insert(BsonDocument document)
        {
            Connection._table.InsertOne(document);
        }

        public BsonDocument FindByName(string name)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", name);

            return Connection._table.Find(filter).ToList()[0];
        }

        public void Updade(BsonDocument document)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", document["name"]);

            Connection._table.UpdateOne(filter, document);
        }
    }
}