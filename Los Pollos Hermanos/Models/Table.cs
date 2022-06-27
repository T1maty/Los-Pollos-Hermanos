namespace Los_Pollos_Hermanos.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual List<Menu> Menu { get; set; }
        public int PlaceId { get; set; }
    }
}
