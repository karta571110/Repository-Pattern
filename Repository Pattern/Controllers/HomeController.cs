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
using Service.Interface;
using Service.Repository;
//using Service.Models.Repository;
namespace Repository_Pattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RPDbContext _context;
        private IRepository<merch> db;
        public HomeController(ILogger<HomeController> logger, RPDbContext context)
        {
            _logger = logger;
            _context = context;
            db = new GenericRepository<merch>(context);
        }
        public IActionResult Index() => View();
        [HttpPost]
        public IActionResult Index(ViewMerch itemDoto)
        {
            if (ModelState.IsValid)
            {
                var instance = new merch
                {
                    Id = itemDoto.Id,
                    Description = itemDoto.Description,
                    Detail = itemDoto.Detail,
                    CreateDate = itemDoto.CreateDate,
                    Name = itemDoto.Name
                };
                    db.Create(instance);
                
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RPlist()
        {
            var testLIst = new List<ViewMerch>();
           
            var query =await  db.GetAll();
            if (query!=null)
            {
                foreach(var e in query)
                {
                    testLIst.Add(new ViewMerch
                    {
                        Id = e.Id,
                        Description = e.Description,
                        Detail = e.Detail,
                        CreateDate = e.CreateDate,
                        Name = e.Name
                    });
                }
            }
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
