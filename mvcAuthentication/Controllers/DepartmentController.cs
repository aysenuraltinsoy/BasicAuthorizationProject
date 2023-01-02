using Microsoft.AspNetCore.Mvc;
using mvcAuthentication.Models.Context;
using mvcAuthentication.Models.Entities;

namespace mvcAuthentication.Controllers
{
    public class DepartmentController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            return View(db.Departments.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            
            return View();
        }
    }
}
