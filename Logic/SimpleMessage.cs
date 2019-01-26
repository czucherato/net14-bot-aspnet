namespace SimpleBot.Logic
{
    public class SimpleMessage
    {
        public SimpleMessage(string id, string username, string text)
        {
            this.Id = id;
            this.User = username;
            this.Text = text;
        }

        public string Id { get; }
        public string User { get; }
        public string Text { get; }
    }
}