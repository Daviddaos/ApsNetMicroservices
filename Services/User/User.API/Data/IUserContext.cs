using MongoDB.Driver;

namespace User.API.Data
{
    using User.API.Entities;

    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
