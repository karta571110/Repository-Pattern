using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Service;
using EntityModels.Models;
using EntityModels.ViewModels;
using Service.Models.Repository;
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
            using (var pr = new ProductRepository(_context))
            {
                var time = DateTime.Now;
                var item = new merch
                {
                    Name = itemDoto.Name,
                    Description = itemDoto.Description,
                    Detail = itemDoto.Detail,
                    CreateDate = time
                };
                pr.Create(item);
            }


            return View();
        }
        [HttpGet]
        public IActionResult RPlist()
        {
            var testLIst = new List<ViewMerch>();
            var query = from q in _context.merches
                        where q.Id != 0
                        select new ViewMerch
                        {
                            Name=q.Name,
                            Detail=q.Detail,
                            Description=q.Description
                        };
            if (query.Any())
                testLIst = query.ToList();
            return View(testLIst);
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
