// Author Ryan Pinkney
// This is the controller for the admin account login


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ismission7RyanPinkney.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ismission7RyanPinkney.Controllers
{
    public class AccountController : Controller
    {
        // Bring in the UserManager
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;


        // Contructor
        public AccountController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {

            userManager = um;
            signInManager = sim;

        }



        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new Login { ReturnUrl = returnUrl });
        }


        // Post method for the login
        [HttpPost]
        public async Task<IActionResult> Login(Login Login)
        {

            // Double check that the inputs are valid
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(Login.Username);

                if (user != null)
                {
                    await signInManager.SignOutAsync();


                    if ((await signInManager.PasswordSignInAsync(user, Login.Password, false, false)).Succeeded)
                    {
                        return Redirect(Login?.ReturnUrl ?? "/Admin");
                    }

                }

            }
            // Return a message if there is an error
            ModelState.AddModelError("", "Invalid name or password");

            // Return the login view
            return View(Login);


        }

        // Route to logout
        public async Task<RedirectResult> Logout(string returnurl = "/")
        {

            await signInManager.SignOutAsync();

            // Redirect to the saved return url
            return Redirect(returnurl);
        }


    }
}
