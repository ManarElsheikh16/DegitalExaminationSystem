using DigitalExaminationSys.Models;
using DigitalExaminationSys.Services;
using DigitalExaminationSys.UnitOfWork;
using DigitalExaminationSys.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DigitalExaminationSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AccountService _AccountService; 
        UserManager<ApplicationUser> _UserManager;
        SignInManager<ApplicationUser> _SignInManager;
        RoleManager<IdentityRole> _roleManager;
        IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, AccountService AccountService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _AccountService = AccountService;
            _UserManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _SignInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateRole(string roleName)
        {

            // Check if the role already exists
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                // Role doesn't exist, so create it
                var newRole = new IdentityRole(roleName);
                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    // Role created successfully
                    TempData["SuccessMessage"] = "Role created successfully.";
                }
                else
                {
                    // Handle role creation failure
                    TempData["ErrorMessage"] = "Role creation failed.";
                }
            }
            else
            {
                // Role already exists
                TempData["ErrorMessage"] = "Role already exists.";
            }

            // Redirect or return a view
            return RedirectToAction("Index"); // Replace with your desired action
        }

        [HttpGet]
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
                IdentityResult identityResult = await _AccountService.AddProfessor(registerationViewModel);
                _unitOfWork.CommitChanges();

                if (identityResult.Succeeded)
                {
                    var user = await _UserManager.FindByNameAsync(registerationViewModel.UserName);

                    await CreateRole("Professor");

                    if (user != null)
                    {
                        if (!await _UserManager.IsInRoleAsync(user, "Student"))
                        {
                            await _UserManager.AddToRoleAsync(user, "Professor");
                        }
                    }
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
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
                IdentityResult identityResult = await _AccountService.AddStudent(registerationViewModel);
                _unitOfWork.CommitChanges();

                if (identityResult.Succeeded)
                {
                   await CreateRole("Student");
                    var user = await _UserManager.FindByNameAsync(registerationViewModel.UserName);

                    if (user != null)
                    {
                        if (!await _UserManager.IsInRoleAsync(user, "Student"))
                        {

                            await _UserManager.AddToRoleAsync(user, "Student");
                        }
                    }
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerationViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid) 
            {
              ApplicationUser user= await _UserManager.FindByNameAsync(loginViewModel.UserName);

                if (user != null)
                {
                    var signInResult =await _SignInManager.PasswordSignInAsync(user, loginViewModel.Password,true,false);
                    if (signInResult.Succeeded) 
                    {
                        bool IsProfessorRole=await _UserManager.IsInRoleAsync(user, "Professor");
                        if (IsProfessorRole)
                        {
                          return RedirectToAction("Index", "Professor");
                        }
                        else
                        {
                           return RedirectToAction("Index", "Student");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName or Password");
                    }
                }
            }
            return View(loginViewModel);
        }


    }
}