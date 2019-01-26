using MongoDB.Bson;
using SimpleBot.Persistence.Repository;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public SimpleBotUser()
        {
            this._rep = new MessageRep();
        }

        private readonly MessageRep _rep;

        public string Reply(SimpleMessage message)
        {
            int contador = 0;

            this.SetMessage(message);
            contador = this._rep.Total(message.User) + 1;

            return $"{message.User} disse '{message.Text}";
        }

        private void SetMessage(SimpleMessage message)
        {
            BsonDocument document = new BsonDocument()
            {
                { "id", message.Id },
                { "nome", message.User },
                { "mensagem", message.Text }
            };

            this._rep.Insert(document);
        }
    }
}