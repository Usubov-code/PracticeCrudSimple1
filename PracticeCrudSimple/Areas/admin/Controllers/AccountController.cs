using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticeCrudSimple.Data;
using PracticeCrudSimple.Models;
using PracticeCrudSimple.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCrudSimple.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;

        public AccountController(AppDbContext context,UserManager<CustomUser> userManager,SignInManager<CustomUser> signInManager)
        {
            _context = context;
           _signInManager = signInManager;
            _userManager = userManager;
        }
        
        
        public IActionResult Register()
        {


            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(VmRegister model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                //CustomUser user = await _userManager.FindByNameAsync(model.UserName);
                //if (user!=null)
                //{
                //    ModelState.AddModelError("UserName","Hal hazirda movcuddur!");
                //}
                //user = await _userManager.FindByEmailAsync(model.Email);
                //if (user != null)
                //{
                //    ModelState.AddModelError("Email", "Hal hazirda movcuddur!");
                //}
               CustomUser user = new CustomUser()
                {

                    FullName = model.FullName,
                    UserName=model.UserName,
                    Email=model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);


                if (!result.Succeeded)
                {
                   
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
               

                    await _signInManager.SignInAsync(user, false);
                   
             
            }
            return RedirectToAction("index", "home");
        }
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Login(VmRegister model)
        //{
        //    if (model.)
        //    {

        //    }
        //}
    }
}
