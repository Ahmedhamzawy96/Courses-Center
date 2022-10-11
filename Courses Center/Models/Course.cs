using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Courses_Center.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Level { get; set; }
        [Required]
        public string Semester { get; set; }
        public bool? ISDeleted { get; set; } = false;


        [Required]
        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Source> Sources { get; set; } = new HashSet<Source>();
        public virtual ICollection<Professor> Professors { get; set; } = new HashSet<Professor>();
    }
}
