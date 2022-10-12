using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Courses_Center.ViewModels
{
    public class CourseDisplay
    {
        [Display(Name = "الجامعة")]
        [Required(ErrorMessage = "يجب اختيار الجامعة")]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار الجامعة")]
        public int UniID { get; set; }

        [Display(Name = "الكلية")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار الكلية")]
        public int ColID { get; set; }

        [Display(Name = "القسم")]
        [Required(ErrorMessage = "يجب اختيار القسم")]
        [RegularExpression("[1-9]{1,}", ErrorMessage = "يجب اختيار القسم")]
        public int DeptID { get; set; }
    }
}
