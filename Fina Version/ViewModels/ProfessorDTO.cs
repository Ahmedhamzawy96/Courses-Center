using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Courses_Center.ViewModels
{
    public class ProfessorDTO
    {
        public int Id { get; set; }

        [Display(Name = "المحاضر")]
        [Required(ErrorMessage = "يجب ادخال اسم المحاضر ")]
        [Remote("CheckProfName", "Professor", ErrorMessage = "هناك محاضر بنفس الاسم")]
        public string Name { get; set; }

        [Display(Name = "المادة")]
        [Required]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار المادة")]
        public int CrsId { get; set; }



        [Display(Name = "الجامعة")]
        [Required]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الجامعة")]
        public int UniID { get; set; }

        [Display(Name = "الكلية")]
        [Required]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الكلية")]
        public int ColID { get; set; }

        [Display(Name = "القسم")]
        [Required]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار القسم")]
        public int DeptID { get; set; }

    }
}
