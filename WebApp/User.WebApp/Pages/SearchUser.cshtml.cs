using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.WebApp.Data;

namespace User.WebApp.Pages
{
    public class SearchUserModel : PageModel
    {
        private readonly ILogger<SearchUserModel> _logger;

        private readonly UserService _userService;

        public IEnumerable<Data.User> Users { get; set; }

        public string SearchFilter { get; set; }

        public SearchUserModel(ILogger<SearchUserModel> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async void OnGet()
        {
            Users = await _userService.GetUsersByFilter(SearchFilter);
        }
    }
}
