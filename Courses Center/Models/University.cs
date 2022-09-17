using System.ComponentModel.DataAnnotations;

namespace Courses_Center.Models
{
    public class University
    {
        [Key]
        public string Name { get; set; }
        public bool ISDeleted { get; set; }
        public virtual ICollection<College> Colleges { get; set; } = new HashSet<College>();

    }
}
