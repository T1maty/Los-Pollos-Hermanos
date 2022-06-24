namespace Los_Pollos_Hermanos.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
    }
}
