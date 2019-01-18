using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dolce_Vita.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dolce_Vita.Controllers
{
    public class MenuController : Controller
    {
        DolceVitaContext db;
        public MenuController(DolceVitaContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IList> GetCategories()
        {
            return await db.Categories.ToListAsync();
        }
    }
}
