using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Bloggie.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signinManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)
        {
            this.userManager = userManager;
            this.signinManager = signinManager;
        }

        [HttpGet]
        public IActionResult Register()
        {


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        
        {

            if(ModelState.IsValid)
            {

                var identityUser = new IdentityUser
                {
                    UserName = registerViewModel.Username,
                    Email = registerViewModel.Email,
                };


                var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);

                if (identityResult.Succeeded)
                {

                    var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");

                    if (roleIdentityResult.Succeeded)
                    {
                        //show success notif
                        return RedirectToAction("Register");
                    }

                }
            }

            //show error notif
            return View();
        }



        [HttpGet]
        public IActionResult Login (string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                return View();
            }

            var signInResult = await signinManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);
                
                if(signInResult != null && signInResult.Succeeded) 
                {
                 if(!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
                 {
                    return Redirect(loginViewModel.ReturnUrl);
                 }

                    return RedirectToAction("Index", "Home");
                }

                return View();

        }




        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    
    }
}
