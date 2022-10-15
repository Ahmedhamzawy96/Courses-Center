using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class Admin
    {
        [Key]
        [Display(Name = "اسم المستخم")]
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name = "الايميل")]
        [Required(ErrorMessage = "يجب ادخال الايميل")]
        [RegularExpression("^\\w+([\\.-]?\\w+)*@\\w+([\\.-]?\\w+)*(\\.\\w{2,3})+$", ErrorMessage = "يجب ان يكون الايميل example@exaple.com")]
        public string Email { get; set; }
        [Display(Name = "الرقم السري")]
        [Required(ErrorMessage = "يجب ادخال الرقم السري ")]
        public string Password { get; set; }
        [Display(Name = " تاكيد الرقم السري ")]
        [Required(ErrorMessage = "يجب ادخال الرقم السري ")]
        [NotMapped]
        [Compare("Password")]
        public string ConfirPassword { get; set; }
        [DefaultValue(false)]
        public bool ISDeleted { get; set; }

    }
}
