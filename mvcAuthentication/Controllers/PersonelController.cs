using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcAuthentication.Models.Context;
using mvcAuthentication.Models.Entities;

namespace mvcAuthentication.Controllers
{
    public class PersonelController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            return View(db.Personels.Include(x=>x.Department).ToList());
        }

        public  IActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments.ToList(),"DepartmentID", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Personels.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
