using System.ComponentModel.DataAnnotations;

namespace Courses_Center.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "يجب ادخال الرقم السرى")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
