using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Center.Models
{
    public class BuyingCart
    {

        [ForeignKey("Buyer")]
        public string BuyUserName { get; set; }

        [ForeignKey("Source")]
        public int SId { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }  
        public decimal Total { get; set; }
        public string BankName { get; set; }
        public int VisaNumber { get; set; }
        public bool ISDeleted { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual Source Source { get; set; }  
        

    }
}
