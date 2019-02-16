using MongoDB.Bson;
using SimpleBot.Persistence.Repository;

namespace SimpleBot.Logic
{
    public class SimpleBotDialog
    {
        public SimpleBotDialog()
        {
            this._rep = new MessageRep();
        }

        private readonly MessageRep _rep;

        public string Reply(Message message)
        {
            int contador = 0;

            this.SetMessage(message);
            contador = this._rep.Total(message.User) + 1;

            return $"{message.User} disse '{message.Text}";
        }

        private void SetMessage(Message message)
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