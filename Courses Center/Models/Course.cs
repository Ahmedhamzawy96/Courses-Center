using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class Course
    {
        public string Name { get; set; }

        //[ForeignKey("Department")]
        public string DeptName { get; set; }
        public string ColName { get; set; }
        public virtual Department Department { get; set; }

        public string Level { get;set; }
        public string Semester { get; set; }    
        public bool ISDeleted { get; set; }

        public virtual ICollection<Source> Sources { get; set; } = new HashSet<Source>();
        public virtual ICollection<Professor> Professors { get; set; } = new HashSet<Professor>();
    }
}
