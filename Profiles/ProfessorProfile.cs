using AutoMapper;
using DigitalExaminationSys.Models;
using DigitalExaminationSys.ViewModels;

namespace DigitalExaminationSys.Profiles
{
    public class ProfessorProfile:Profile
    {
        public ProfessorProfile() 
        {
            CreateMap<ApplicationUser, Professor>();
            CreateMap<RegisterationViewModel, Professor>();
        }
    }
}
