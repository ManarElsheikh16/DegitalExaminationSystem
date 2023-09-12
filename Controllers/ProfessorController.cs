using DigitalExaminationSys.Models;
using DigitalExaminationSys.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace DigitalExaminationSys.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IUnitOfWork _unitOfWork;

        public ProfessorController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork= unitOfWork;
        }
        [Authorize(Roles = "Professor")]
        public IActionResult Index()
        {
            return View();
        }

     

        [Authorize(Roles = "Professor")]

        public IActionResult AllExams()
        {
          
            return View();
        }

        public List<Course> GetAllCoursesByProfessorId()
        {
            string ProfessorId=User.FindFirstValue(claimType:ClaimTypes.NameIdentifier);
            List<Course> ProfessorCourses= _unitOfWork.CourseRepository.GetByExpressions(crs => crs.ProfessorId ==ProfessorId).ToList();

            return ProfessorCourses;
        }
        [Authorize(Roles = "Professor")]
        public IActionResult CreateExam()
        {
            List<Course> ProfessorCourses = GetAllCoursesByProfessorId();


            return View(ProfessorCourses);
        }
        [Authorize(Roles = "Professor")]

        public IActionResult Reports()
        {
            return View();
        }


    }
}