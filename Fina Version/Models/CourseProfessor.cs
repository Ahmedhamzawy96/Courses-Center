using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class CourseProfessor
    {
        [ForeignKey("Professor")]
        public int ProfId { get; set; }
        [ForeignKey("Course")]

        public int CrsId { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Course Course { get; set; }

    }
}
