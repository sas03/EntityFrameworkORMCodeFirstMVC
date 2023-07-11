using EntityFrameworkMVC.Models;
using EntityFrameworkMVC.Repositories;
using EntityFrameworkMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFrameworkMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var context = new SavingContext())
            {
                IQueryable<Person> query = context.Person.Where(p => p.Name == "Mr Person");

                query = query.Include(p => p.SavingAccounts);

                Person person = query.FirstOrDefault();

                return View(person);
            }
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