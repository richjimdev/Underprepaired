using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Underprepaired.Data;
using Underprepaired.Models;
using Underprepaired.Models.Interfaces;
using Underprepaired.Models.ViewModels;

namespace Underprepaired.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private UnderprepairedDbContext _context;
        private IEmailSender _email;
        private ApplicationDbContext _identity;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, UnderprepairedDbContext context, IEmailSender email, ApplicationDbContext identity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _email = email;
            _identity = identity;
        }

        /// <summary>
        /// Renders initial register view
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="rvm">view model for registration</param>
        /// <returns>redirects to home page</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                CheckUserRoleExists();

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                };

                Cart userCart = new Cart()
                {
                    Username = rvm.Email
                };

                _context.Carts.Add(userCart);
                await _context.SaveChangesAsync();


                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    List<Claim> myClaims = new List<Claim>()
                    {
                        fullNameClaim,
                        emailClaim
                    };

                    if (rvm.Email == "amanda@codefellow.com" || rvm.Email == "richjim89@gmail.com" || rvm.Email == "admintest2@test.com")
                    {
                        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                    }

                    await _userManager.AddToRoleAsync(user, UserRoles.Member);

                    await _userManager.AddClaimsAsync(user, myClaims);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    await _email.SendEmailAsync(rvm.Email, "Registration Complete", "<p> Thanks for registering! </p>");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View(rvm);
        }

        /// <summary>
        /// Renders view for user login
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Logins the user
        /// </summary>
        /// <param name="lvm">login view model</param>
        /// <returns>redirects user to home page</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Try again");
                }

            }

            return View();
        }

        /// <summary>
        /// Logout the user
        /// </summary>
        /// <returns>redirects to the home page</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Renders secret founder page
        /// </summary>
        /// <returns>founder view</returns>
        [HttpGet]
        [Authorize(Policy = "FounderEmailPolicy")]
        public IActionResult Founder()
        {
            return View();
        }

        public void CheckUserRoleExists()
        {
            if (!_identity.Roles.Any())
            {
                List<IdentityRole> Roles = new List<IdentityRole>
                {
                    new IdentityRole{Name = UserRoles.Admin,
                    NormalizedName=UserRoles.Admin.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString()},
                    new IdentityRole{Name = UserRoles.Member,
                    NormalizedName=UserRoles.Member.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                };

                foreach (var role in Roles)
                {
                    _identity.Roles.Add(role);
                    _identity.SaveChanges();
                }
            }
        }
    }
}
