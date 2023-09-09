using System.ComponentModel.DataAnnotations;

namespace DigitalExaminationSys.ViewModels
{
    public class RegisterationViewModel
    {
        public string FullName { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
