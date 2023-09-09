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

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]

        public IActionResult AllResponses()
        {
            return View();
        }
        [Authorize]

        public IActionResult GetExam()
        {
            return View();
        }

      


    }
}