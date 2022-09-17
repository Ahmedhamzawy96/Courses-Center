using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class College
    {
        public string Name { get; set; }
        public bool ISDeleted { get; set; }

        [ForeignKey("University")]
        public string UniName { get; set; }  
        public virtual University University  { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
