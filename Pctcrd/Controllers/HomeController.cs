using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pctcrd.Db_context;
using Pctcrd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pctcrd.Controllers
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
            officeContext db = new officeContext();
            var res = db.Employees.ToList();
            db.SaveChanges();
            return View(res);
        }


        [HttpGet]
        public IActionResult Addemp()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Addemp(modemp obj)
        {
            officeContext db = new officeContext();
            Employee tb = new Employee();
            tb.Id = obj.Id;
            tb.Name = obj.Name;
            tb.Email = obj.Email;
            tb.MbN0 = obj.MbN0;
            tb.Salary = obj.Salary;
            if (obj.Id == 0)
            {
            db.Employees.Add(tb);
            db.SaveChanges();

            }
            else
            {
                db.Entry(tb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            officeContext db = new officeContext();
         
            var res = db.Employees.Where(m => m.Id == id).First();
            db.Employees.Remove(res);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       

        public IActionResult Edit(int Id)
        {
            officeContext db = new officeContext();
            modemp emp = new modemp();
            var Edititem = db.Employees.Where(a => a.Id == Id).First();
            emp.Id = Edititem.Id;
            emp.Name = Edititem.Name;
            emp.Email = Edititem.Email;
            emp.MbN0 = Edititem.MbN0;
            emp.Salary = Edititem.Salary;
            return View("AddEmp", emp);
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
