using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Logic;
using System.Collections;
using System.Collections.Generic;

namespace SimpleBot.Persistence
{
    public sealed class Connection
    {
        public Connection() { }

        private static MongoClient _client;
        private static IMongoDatabase _database;
        private static IMongoCollection<BsonDocument> _table;
        private static readonly Connection _instance = new Connection();

        public static Connection Open()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("bot");
            _table = _database.GetCollection<BsonDocument>("transcript");

            return _instance;
        }

        public static int Total(string user)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("nome", user);

            return _table.Find(filter).ToList().Count;
        }

        public static void Insert(BsonDocument document)
        {
            _table.InsertOne(document);
        }
    }
}