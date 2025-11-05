namespace UniFilteringproject.Models
{
    public class Haiil
    {
        public int Id { get; set; }
        public List<CartItem> items { get; set; } = new();
        public bool IsFull { get; set; }
    }
    public class CartItem
    {
        public int MalshabId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
