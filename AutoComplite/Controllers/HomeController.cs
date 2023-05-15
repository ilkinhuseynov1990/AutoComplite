using AutoComplite.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoComplite.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _dbcontext;
        public HomeController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AutoComplete(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return Json("Not text Typing");
            }

            var studnets = from s in _dbcontext.Students select s;

            studnets = studnets.Where(s => s.StudentName.Contains(text));

            return Json(studnets);
        }
    }
}
