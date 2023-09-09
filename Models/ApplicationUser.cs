using Microsoft.AspNetCore.Identity;
namespace DigitalExaminationSys.Models

{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
