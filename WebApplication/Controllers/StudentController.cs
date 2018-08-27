using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student 
        public ActionResult Registation()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Registation(Student std)
        {
            return View();
        }


    }
}