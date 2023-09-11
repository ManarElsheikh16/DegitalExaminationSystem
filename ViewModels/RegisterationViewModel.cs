using System.ComponentModel.DataAnnotations;

namespace DigitalExaminationSys.ViewModels
{
    public class RegisterationViewModel
    {
        [Required(ErrorMessage = "Username is required.")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage ="Invaild Email Format.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8,ErrorMessage ="Password must be at least 8 character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
