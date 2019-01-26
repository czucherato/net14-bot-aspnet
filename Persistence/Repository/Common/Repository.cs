using SimpleBot.Persistence.Context;

namespace SimpleBot.Persistence.Repository.Common
{
    public abstract class Repository
    {
        public Repository(string tableName)
        {
            Connection.Open(tableName);
        }
    }
}