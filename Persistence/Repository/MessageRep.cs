using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Persistence.Context;

namespace SimpleBot.Persistence.Repository
{
    public class MessageRep : Common.Repository
    {
        public MessageRep()
            : base("message") { }

        public void Insert(BsonDocument document)
        {
            Connection._table.InsertOne(document);
        }

        public int Total(string user)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", user);

            return Connection._table.Find(filter).ToList().Count;
        }
    }
}