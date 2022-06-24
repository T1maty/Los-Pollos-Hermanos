namespace Los_Pollos_Hermanos.Models
{
    public class Menu
    {
        public string Name { get; set; }
        public DateTime? Discount { get; set; }
        public int Price { get; set; }
        public object User { get; internal set; }
    }
}
