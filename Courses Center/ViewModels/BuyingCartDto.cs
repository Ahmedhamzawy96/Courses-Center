namespace Courses_Center.ViewModels
{
    public class BuyingCartDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string Title { get; set; }
       
    }
}
