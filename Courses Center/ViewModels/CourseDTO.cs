using Courses_Center.Models;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Courses_Center.ViewModels
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Display(Name = "الجامعة")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
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

        [Display(Name = "اسم المادة")]
        [Required(ErrorMessage = "يجب ادخال اسم المادة ")]
        //[RegularExpression(, ErrorMessage = "يجب الا يقل اسم المادة عن اربع حروف")]
        public string Name { get; set; }

        [Display(Name = "المستوي")]
        [Required(ErrorMessage ="يجب ادخال اسم المستوي ")]
        //[RegularExpression(, ErrorMessage = "يجب الا يقل اسم المادة عن حرفين حروف")]
        public string Level { get;set; }

        [Display(Name ="الترم")]
        [Required(ErrorMessage ="يجب ادخال اسم الترم")]
       // [RegularExpression(,ErrorMessage = "يجب الا يقل اسم المادة عن حرفين حروف")]
        public string Semester { get; set; }    

    }
}
