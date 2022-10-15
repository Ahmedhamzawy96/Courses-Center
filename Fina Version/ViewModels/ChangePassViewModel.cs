using System.ComponentModel.DataAnnotations;

namespace Courses_Center.ViewModels
{
    public class ChangePassViewModel
    {
        [Required(ErrorMessage = "يجب ادخال الرقم السرى")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "يجب ادخال الرقم السرى")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "يجب ادخال الرقم السرى")]
        [Compare(nameof(NewPassword), ErrorMessage = "الرقم السرى غير متطابق")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
