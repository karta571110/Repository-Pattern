using EntityModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Service.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_Pattern.Controllers
{
    public class whateverController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RPDbContext _context;
        public whateverController(RPDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Viewwhatever viewitem)
        {
            using (var db = new CategoryRepository(_context))
            {
                await db.Create(viewitem);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> weList()
        {
            using (var db = new CategoryRepository(_context))
            {
                var list = await db.GetAll();
                return View(list.ToList());
            }
        }
        public IActionResult Edit() => View();
        [HttpPost]
        public async Task<IActionResult> Edit(Viewwhatever viewitem)
        {
            Console.WriteLine(viewitem);
            if (ModelState.IsValid)
            {
                using (var db = new CategoryRepository(_context))
                {
                    await db.Update(viewitem);
                }
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            
            using(var db=new CategoryRepository(_context))
            {
                await db.Delete(id);
            }
           return RedirectToAction("weList");
        }
    }
}
