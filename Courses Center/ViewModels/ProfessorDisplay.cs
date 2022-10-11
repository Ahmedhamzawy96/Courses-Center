using System.ComponentModel.DataAnnotations;

namespace Courses_Center.ViewModels
{
    public class ProfessorDisplay
    {

        [Display(Name = "الجامعة")]
        [Required]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار الجامعة")]
        public int UniID { get; set; }

        [Display(Name = "الكلية")]
        [Required]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار الكلية")]

        public int ColID { get; set; }

        [Display(Name = "القسم")]
        [Required]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار القسم")]

        public int DeptID { get; set; }

        [Display(Name = "المادة")]
        [Required]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار المادة")]

        public int CrsID { get; set; }
    }
}
