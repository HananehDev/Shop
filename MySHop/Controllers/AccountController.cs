using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MySHop.Data.Repositories;
using MySHop.Models;
using System.Security.Claims;

namespace MySHop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Register
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
        #endregion Register

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            

            var user = _userRepository.GetUserForLogin(login.Email.ToLower() , login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "اطلاعات وارد شده صحیح نیست ");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                // new Claim("CodeMeli", user.Email),
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principal, properties);


            return Redirect("/");
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        #endregion
    }
}
