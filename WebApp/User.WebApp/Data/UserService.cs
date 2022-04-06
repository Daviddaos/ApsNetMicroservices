using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace User.WebApp.Data
{
    public class UserService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<User>> GetUsersByFilter(string filter)
        {
            var httpClient = _httpClientFactory.CreateClient("UserApi");
            var result = await httpClient.GetFromJsonAsync<IEnumerable<User>>(filter);
            return result;
        }

        public async Task AddUser(User user)
        {
            var httpClient = _httpClientFactory.CreateClient("UserApi");
            var result = await httpClient.PostAsJsonAsync<User>("", user);
        }
    }
}
