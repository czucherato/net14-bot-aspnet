using MongoDB.Bson;
using SimpleBot.Persistence;
using System.Collections.Generic;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            int contador = 0;

            Connection.Open();

            BsonDocument document = new BsonDocument()
            {
                { "id", message.Id },
                { "nome", message.User },
                { "mensagem", message.Text }
            };

            Connection.Insert(document);

            int results = Connection.Total(message.User);
            contador = results + 1;

            return $"{message.User} disse '{message.Text}";
        }
    }
}