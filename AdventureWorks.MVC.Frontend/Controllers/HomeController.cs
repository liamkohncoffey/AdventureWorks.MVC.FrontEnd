using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Client;
using AdventureWorks.MVC.FrontEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdventureWorks.MVC.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdventureWorksApiService _adventureWorksApiService;

        public HomeController(ILogger<HomeController> logger, IAdventureWorksApiService adventureWorksApiService)
        {
            _logger = logger;
            _adventureWorksApiService = adventureWorksApiService;
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            Console.WriteLine(token);
            try
            {
                var test = await _adventureWorksApiService.GetUserAccount(1, $"Bearer {token}", cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
