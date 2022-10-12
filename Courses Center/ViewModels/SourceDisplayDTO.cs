using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Courses_Center.ViewModels
{
    public class SourceDisplayDTO
    {
        [Display(Name = "الجامعة")]
        [Required(ErrorMessage = "يجب اختيار الجامعة")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الجامعة")]
        public int UniID { get; set; }

        [Display(Name = "الكلية")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الكلية")]
        public int ColID { get; set; }

        [Display(Name = "القسم")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار القسم")]
        public int DeptID { get; set; }

        [Display(Name = "المادة")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار المادة")]
        public int CrsID { get; set; }

        [Display(Name = "الماحضر")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار المحاضر")]
        public int ProfID { get; set; }

        [Display(Name ="نوع المصدر ")]
        [Required(ErrorMessage ="يجب اختيار نوع المصدر ")]
        public string SourceType { get; set; }
    }
}
