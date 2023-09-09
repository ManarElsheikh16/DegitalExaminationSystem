using AutoMapper;
using DigitalExaminationSys.Models;
using DigitalExaminationSys.ViewModels;

namespace DigitalExaminationSys.Profiles
{
    public class StudentProfile: Profile
    {
        public StudentProfile() 
        {
            CreateMap<ApplicationUser, Student>();
            CreateMap<RegisterationViewModel,Student>();
        }
    }
}
