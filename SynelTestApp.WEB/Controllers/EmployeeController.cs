using Microsoft.AspNetCore.Mvc;

namespace SynelTestApp.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
