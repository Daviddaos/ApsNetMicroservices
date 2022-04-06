using System.Collections.Generic;
using System.Threading.Tasks;

namespace User.API.Repositories
{
    using User.API.Entities;

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersByFilter(string filter);

        Task AddUser(User user);
    }
}
