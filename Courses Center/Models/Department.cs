using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class Department
    {
        public string Name { get; set; }    
        public bool ISDeleted { get; set; }

        //[ForeignKey("College")]
        public string ColName { get; set; }
        public string UniName { get; set; }
        public virtual College College { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();



    }
}
