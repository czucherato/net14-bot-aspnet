using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            string conString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(conString);

            var db = client.GetDatabase("bot");
            var tb = db.GetCollection<BsonDocument>("transcript");

            BsonDocument bson = new BsonDocument()
            {
                { "id", message.Id },
                { "nome", message.User },
                { "mensagem", message.Text }
            };

            tb.InsertOne(bson);

            return $"{message.User} disse '{message.Text}";
        }
        public static async Task<List<BsonDocument>> GetValues(Task<IAsyncCursor<BsonDocument>> queryTask)
        {
            var cursor = await queryTask;
            return await cursor.ToListAsync<BsonDocument>();
        }

    }
}