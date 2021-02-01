using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Service;
using Service.Models;
using Infra.ViewModels;

namespace Repository_Pattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RPDbContext _context;

        public HomeController(ILogger<HomeController> logger, RPDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index() => View();
        [HttpPost]
        public IActionResult Index(ViewMerch itemDoto)
        {

            var time = DateTime.Now;
            var item = new merch
            {
                Name = itemDoto.Name,
                Description = itemDoto.Description,
                Detail = itemDoto.Detail,
                CreateDate = time
            };

            _context.merches.Add(item);
            _context.SaveChanges();


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
