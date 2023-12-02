using CleanMVC.Domain.Account;
using CleanMVC.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CleanMVC.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
        }

        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            return View(new LoginViewModel()
            {
                ReturnURL = returnURL
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authenticate.Authenticate(model.Email, model.Password);

            if (result)
            {
                if(string.IsNullOrEmpty(model.ReturnURL))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnURL);            
            } else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. Password must be strong");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authenticate.RegisterUser(model.Email, model.Password);

            if (result)
                return Redirect("/");

            ModelState.AddModelError(string.Empty, "Invalid register attempt. Password must be strong");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }
    }
}
