using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "اسم القسم")]
        [Required(ErrorMessage ="يجب ادخال اسم القسم")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "لا يجب ان يحتوى الحقل على ارقام")]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool ISDeleted { get; set; }
        [ForeignKey("College")]
        [Required(ErrorMessage = "يجب اختيار الكلية")]
        [RegularExpression("^[1-9]+\\d*$", ErrorMessage = "يجب اختيار الكلية")]
        public int ColID { get; set; }
        public virtual College College { get; set; }

        //[ForeignKey("University")]
        //public int UniID { get; set; }
        //public virtual University University { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();



    }
}
