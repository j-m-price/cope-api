using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace core_api.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            return View ();
        }
    }
}