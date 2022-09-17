using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class Admin
    {
        [Key]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ISDeleted { get; set; }

    }
}
