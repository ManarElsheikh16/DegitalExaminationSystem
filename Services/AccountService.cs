using AutoMapper;
using DigitalExaminationSys.Models;
using DigitalExaminationSys.UnitOfWork;
using DigitalExaminationSys.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DigitalExaminationSys.Services
{
    public class AccountService
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        IUnitOfWork _UnitOfWork;
        IMapper _Mapper;
        public AccountService(IUnitOfWork UnitOfWork, IMapper Mapper,
                    UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _UnitOfWork= UnitOfWork;
            _Mapper= Mapper;
            _userManager= userManager;
            _signInManager= signInManager;
        } 
        
        public async Task<IdentityResult> AddStudent(RegisterationViewModel registerationViewModel)
        {
            //save in applicationUser table
            ApplicationUser applicationUser=_Mapper.Map<ApplicationUser>(registerationViewModel);
            IdentityResult IdentityResult=await _userManager.CreateAsync(applicationUser, registerationViewModel.Password);

            List<Claim> addClaim = new List<Claim>();

            await _signInManager.SignInWithClaimsAsync(applicationUser, false, addClaim);

            //save in Student table

            Student Student = _Mapper.Map<Student>(applicationUser);
            _UnitOfWork.StudentRepository.Insert(Student);
            _UnitOfWork.SaveChanges();

            return IdentityResult;
        }
        public async Task<IdentityResult> AddProfessor(RegisterationViewModel registerationViewModel)
        {

            //save in applicationUser table

            ApplicationUser applicationUser = _Mapper.Map<ApplicationUser>(registerationViewModel);
            IdentityResult IdentityResult = await _userManager.CreateAsync(applicationUser, registerationViewModel.Password);

            List<Claim> addClaim = new List<Claim>();

            await _signInManager.SignInWithClaimsAsync(applicationUser, false, addClaim);

            //save in Professor table

            Professor professor = _Mapper.Map<Professor>(applicationUser);
            _UnitOfWork.ProfessorRepository.Insert(professor);
            _UnitOfWork.SaveChanges();

            return IdentityResult;

        }
    }
}
