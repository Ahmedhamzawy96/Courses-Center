using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class College
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="اسم الكلية")]
        [Required(ErrorMessage = "يجب ادخال اسم الكلية")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "لا يجب ان يحتوى الحقل على ارقام")]
        [Remote("CheckNameColl", "Collage", AdditionalFields = "UniID", ErrorMessage = "هناك كلية بنفس الاسم فى هذة الجامعة")]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool ISDeleted { get; set; }

        [Required(ErrorMessage = "يجب اختيار الجامعة")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الجامعة")]
        [ForeignKey("University")]
        public int UniID { get; set; }
        public virtual University University { get; set; }

        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
