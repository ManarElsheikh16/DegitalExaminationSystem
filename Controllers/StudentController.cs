using DigitalExaminationSys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DigitalExaminationSys.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StudentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Student")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Student")]
        public IActionResult AllResponses()
        {
            return View();
        }
        [Authorize(Roles ="Student")]

        public IActionResult GetExam()
        {
            return View();
        }

      


    }
}