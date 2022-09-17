using System.ComponentModel.DataAnnotations;

namespace Courses_Center.Models
{
    public class Buyer
    {
        [Key]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool ISDeleted { get; set; }


        public virtual ICollection<BuyingCart> BuyingCarts { get; set; } = new HashSet<BuyingCart>();
    }
}
