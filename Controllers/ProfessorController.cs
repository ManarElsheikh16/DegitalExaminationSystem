using DigitalExaminationSys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DigitalExaminationSys.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProfessorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]

        public IActionResult AllExams()
        {
            return View();
        }
        [Authorize]

        public IActionResult CreateExam()
        {
            return View();
        }
        [Authorize]

        public IActionResult Reports()
        {
            return View();
        }


    }
}