using Microsoft.AspNetCore.Mvc;

namespace AWSProjectAPI.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
