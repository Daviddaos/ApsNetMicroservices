using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace User.API.Data
{
    using User.API.Entities;

    public class UserContext : IUserContext
    {
        public IMongoCollection<User> Users { get; }

        public UserContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Users = database.GetCollection<User>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            UserContextSeed.SeedData(Users);
        }
    }
}
