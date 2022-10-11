using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Courses_Center.ViewModels
{
    public class UProfileViewModel
    {
       

        [Required(ErrorMessage = "يجب ادخال البريد الالكترونى")]
        [DataType(DataType.EmailAddress, ErrorMessage = "اليريدالالكترونى الذى ادخلته غير صالح")]
        public string EmailProfile { get; set; }



        [Required(ErrorMessage = "يجب ادخال الاسم الاول")]
        [RegularExpression("^[^0-9]{3,}$", ErrorMessage = "لايجب ان يحوى الاسم على ارقام")]
        public string FnameProfile { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم الثانى")]
        [RegularExpression("^[^0-9]{3,}$", ErrorMessage = "لايجب ان يحوى الاسم على ارقام")]
        public string LnameProfile { get; set; }
    }
}
