using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Dolce_Vita.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Dolce_Vita.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        DolceVitaContext db;
        public AdminController(DolceVitaContext context)
        {
            db = context;
        }


        public IActionResult Cabinet()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }



        //Categories
        public IActionResult Categories() 
        {
            return View(db.Categories.ToList());
        }


        //Получение списка категорий
        [HttpGet]
        public async Task<IList> GetCategory()
        {
            return await db.Categories.ToListAsync();
        }
        //Добавление категории
        [HttpPost]
        [ActionName("AddCategory")]
        public async Task<IActionResult> AddCategory(string name)
        {
            if (name == null)
                return BadRequest();

            await db.Categories.AddAsync(new Category { Name = name });
            await db.SaveChangesAsync();



            return RedirectToAction("Categories", "Admin");
        }
        //Удаление категории
        [HttpPost]
        [ActionName("DelCategory")]
        public async Task<IList> DelCategory([FromBody] Category cat)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(x => x.Id == cat.Id);
            if (category != null)
            {
                db.Remove(category);
                await db.SaveChangesAsync();
            }
            return await db.Categories.ToListAsync();
        }


        //Dishes
        public IActionResult Dishes()
        {
            return View();
        }

        
        
       
        //Get Dishes 
        [HttpGet]
        public async Task<IList> GetDishes(int? id)
        {
            if (id == null)
                return await db.Dishes.ToListAsync();
            else
                return await db.Dishes.Where(x => x.CategoryID == id).Select(x => new { x.Id, x.Name, x.Price, x.Properties, x.CategoryID}).ToListAsync();
        }

        //Add Dish
        [HttpPost]
        [ActionName("AddDish")]
        public async Task<IActionResult> AddDish(string name, decimal price, string property, int category)
        {
            if (name == null)
                return NotFound();

            await db.Dishes.AddAsync(new Dish { Name = name , Price = price, Properties = property, CategoryID = category});
            await db.SaveChangesAsync();

            return RedirectToAction("Categories", "Admin");
        }
    }
}
