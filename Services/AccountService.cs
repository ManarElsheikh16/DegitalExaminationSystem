using AutoMapper;
using DigitalExaminationSys.Models;
using DigitalExaminationSys.UnitOfWork.Interfaces;
using DigitalExaminationSys.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace DigitalExaminationSys.Services
{
    public class AccountService
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        IUnitOfWork _UnitOfWork { get; set; }
        IMapper _Mapper { get; set; }
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
            Student Student=_Mapper.Map<Student>(registerationViewModel);
            _UnitOfWork.StudentRepository.Insert(Student);
            _UnitOfWork.SaveChanges();

            ApplicationUser applicationUser=_Mapper.Map<ApplicationUser>(registerationViewModel);
            IdentityResult IdentityResult=await _userManager.CreateAsync(applicationUser, registerationViewModel.Password);

            List<Claim> addClaim = new List<Claim>();

            await _signInManager.SignInWithClaimsAsync(applicationUser, false, addClaim);

            return IdentityResult;
        }
        public async Task<IdentityResult> AddProfessor(RegisterationViewModel registerationViewModel)
        {
            Professor professor=_Mapper.Map<Professor>(registerationViewModel);
            _UnitOfWork.ProfessorRepository.Insert(professor);
            _UnitOfWork.SaveChanges();

            ApplicationUser applicationUser = _Mapper.Map<ApplicationUser>(registerationViewModel);
            IdentityResult IdentityResult = await _userManager.CreateAsync(applicationUser, registerationViewModel.Password);

            List<Claim> addClaim = new List<Claim>();

            await _signInManager.SignInWithClaimsAsync(applicationUser, false, addClaim);

            return IdentityResult;

        }
    }
}
