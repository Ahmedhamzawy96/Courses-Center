using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Courses_Center.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "اسم الجامعة")]
        [Required(ErrorMessage = "يجب ان تدخل اسم الجامعة")]
        //[RegularExpression("^[^0-9]+$", ErrorMessage = "لا يجب ان يحتوى الحقل على ارقام")]
        [Remote("CheckNameUni", "University", ErrorMessage = "هناك جامعة بنفس الاسم")]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool ISDeleted { get; set; }
        public virtual ICollection<College> Colleges { get; set; } = new HashSet<College>();

    }
}
