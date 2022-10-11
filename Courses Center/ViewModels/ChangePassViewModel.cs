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
        [Compare(nameof(ConfirmPassword),ErrorMessage ="الرقم السرى غير متطابق")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "يجب ادخال الرقم السرى")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
