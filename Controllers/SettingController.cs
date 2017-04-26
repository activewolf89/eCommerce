using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class SettingController: Controller 
    {
        [HttpGet]
        [Route("/settings")]
        public IActionResult settings()
        {
            return View();
        }
    }
}