using MongoDB.Driver;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace User.API.Repositories
{
    using User.API.Data;
    using User.API.Entities;

    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext;

        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task AddUser(User user)
        {
            await _userContext.Users.InsertOneAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsersByFilter(string filter)
        {
            var filters = RemoveDiacritics(filter).ToLower().Split(' ');

            var filterDefinitions = new List<FilterDefinition<User>>();

            foreach (string filterItem in filters)
            {
                if (string.IsNullOrEmpty(filterItem))
                    continue;

                var userNameFilter = Builders<User>.Filter.Where(u => u.UserName.ToLower().Contains(filterItem));
                var nameFilter = Builders<User>.Filter.Where(u => u.Name.ToLower().Contains(filterItem));
                var lastNameFilter = Builders<User>.Filter.Where(u => u.LastName.ToLower().Contains(filterItem));

                filterDefinitions.Add(userNameFilter);
                filterDefinitions.Add(nameFilter);
                filterDefinitions.Add(lastNameFilter);
            }

            return await _userContext.Users.Find(Builders<User>.Filter.Or(filterDefinitions)).ToListAsync();
        }

        private string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
