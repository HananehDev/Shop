using Microsoft.AspNetCore.Mvc;
using MySHop.Data.Repositories;
using MySHop.Models;

namespace MySHop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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


            if (_userRepository.IsExistuserByEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت نام کرده است ");
                return View(register);
            }

            Users user = new Users()
            {
                Email = register.Email.ToLower(),
                Password = register.Password,
                IsAdmin = false,
                DateRegister = DateTime.Now
            };
            
            _userRepository.AddUser(user);
            return View("SuccessRegister" , register);
        }
    }
}
