using DigitalExaminationSys.Models;
using DigitalExaminationSys.Services;
using DigitalExaminationSys.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace DigitalExaminationSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
     //   private readonly AccountService _AccountService; 
      //  UserManager<ApplicationBuilder> _UserManager;               

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
         //   _AccountService = AccountService;
          //  _UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegisterProfessor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterProfessor(RegisterationViewModel registerationViewModel)
        {
            if(ModelState.IsValid)
            {
                //IdentityResult identityResult=await _AccountService.AddProfessor(registerationViewModel);

                //if (identityResult.Succeeded)
                //{
                //    var user = await _UserManager.FindByNameAsync(registerationViewModel.UserName);

                //    if (user != null)
                //    {
                //        await _UserManager.AddToRoleAsync(user, "Professor");
                //    }
                //    return RedirectToAction("Login");
                //}
                //else
                //{
                //    foreach (var item in identityResult.Errors)
                //    {
                //        ModelState.AddModelError("", item.Description);
                //    }
                //}
            }
            return View();
        }
        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudent(RegisterationViewModel registerationViewModel)
        {
            if (ModelState.IsValid)
            {
                //IdentityResult identityResult = await _AccountService.AddProfessor(registerationViewModel);

                //if (identityResult.Succeeded)
                //{

                //    var user = await _UserManager.FindByNameAsync(registerationViewModel.UserName);

                //    if (user != null)
                //    {
                //        await _UserManager.AddToRoleAsync(user, "Student");
                //    }
                //    return RedirectToAction("Login");
                //}
                //else
                //{
                //    foreach (var item in identityResult.Errors)
                //    {
                //        ModelState.AddModelError("", item.Description);
                //    }
                //}
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }


    }
}