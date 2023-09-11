using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigitalExaminationSys.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage = "Password must be at least 8 character")]
        public string Password { get; set; }
    }
}
