namespace Los_Pollos_Hermanos.Models
{
    public class Menu
    {


        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; } 
        public virtual User User { get; set; }
        public int UserId { get; set; }
     
        
    }
}
