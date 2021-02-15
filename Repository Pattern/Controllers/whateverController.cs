using EntityModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
//using Service.Models.Repository;
using Service.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Interface;
using EntityModels.Models;
using Service.Repository;

namespace Repository_Pattern.Controllers
{
    public class whateverController : Controller
    {
        
        private readonly RPDbContext _context;
        private IRepository<whatever> db;
        public whateverController(RPDbContext context)
        {
            
            _context = context;
            //db = new CategoryRepository(context);
            db = new GenericRepository<whatever>(context);
        }
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Viewwhatever instance)
        {
            if (ModelState.IsValid)
            {
                var time = DateTime.Now;
                var item = new whatever
                {
                    Name = instance.Name,
                    Description = instance.Description,
                    Detail = instance.Detail,
                    CreateDate = time
                };
                await db.Create(item);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> weList()
        {
            var getter = new List<Viewwhatever>();
            var list = await db.GetAll();
            foreach (var e in list)
            {
                getter.Add(new Viewwhatever
                {
                    Id = e.Id,
                    Name = e.Name,
                    CreateDate = e.CreateDate,
                    Description = e.Description,
                    Detail = e.Detail
                });
            }
            return View(getter);

        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var instance = await db.Get(e=>e.Id==id);
            var item = new Viewwhatever
            {
                Id = instance.Id,
                Name = instance.Name,
                Description = instance.Description,
                Detail = instance.Detail,
                CreateDate = instance.CreateDate
            };
            return View(item);
        }
        public IActionResult Edit() => View();
        [HttpPost]
        public async Task<IActionResult> Edit(Viewwhatever viewitem)
        {
            Console.WriteLine(viewitem);
            if (ModelState.IsValid)
            {
                var instance = new whatever
                {
                    Id = viewitem.Id,
                    Description = viewitem.Detail,
                    Detail = viewitem.Detail,
                    Name = viewitem.Name,
                    CreateDate = viewitem.CreateDate
                };
                    await db.Update(instance);
                
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await db.Delete(e => e.Id == id);
            return RedirectToAction("weList");
        }
    }
}
