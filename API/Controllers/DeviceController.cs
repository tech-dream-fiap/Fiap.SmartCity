using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
