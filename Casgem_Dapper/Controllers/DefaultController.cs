using Microsoft.AspNetCore.Mvc;

namespace Casgem_Dapper.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
