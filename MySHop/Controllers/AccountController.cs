using Microsoft.AspNetCore.Mvc;
using MySHop.Models;

namespace MySHop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            return View();
        }
    }
}
