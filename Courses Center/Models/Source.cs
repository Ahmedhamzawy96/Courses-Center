using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class Source
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }    
        public string Type { get; set; }
        public string Url { get; set; } 
        public string Notes { get; set; }   
        public int CountOfBuy { get; set; } 
        public bool ISDeleted { get; set; }

        [ForeignKey("Professor")]
        public int ProfID { get; set; }
        public virtual Professor  Professor { get; set; }

       //[ForeignKey("Course")]
        public string CrsName { get; set; }
        public string DeptName { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<BuyingCart> BuyingCarts { get; set; } = new HashSet<BuyingCart>();




    }
}
