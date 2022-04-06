using MongoDB.Driver;
using System.Collections.Generic;

namespace User.API.Data
{
    using User.API.Entities;

    public class UserContextSeed
    {
        public static async void SeedData(IMongoCollection<User> mongoCollection)
        {
            var existCollection = await mongoCollection.FindAsync(c => true);

            if (!existCollection.Any())
            {
                await mongoCollection.InsertManyAsync(GetPreconfiguredUsers());
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            var users = new List<User>();

            for (int i = 0; i < 1000; i++)
            {
                users.Add(new User() { Name = $"Number { i + 1 }", LastName = $"Last name { i + 1}", UserName = $"user{ i }" });
            }

            return users;
        }
    }
}
