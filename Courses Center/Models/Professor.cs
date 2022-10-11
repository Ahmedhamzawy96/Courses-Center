using Courses_Center.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace Courses_Center.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }    
        public bool ISDeleted { get; set; }

        public virtual ICollection<Source> Sources { get; set; } = new HashSet<Source>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
