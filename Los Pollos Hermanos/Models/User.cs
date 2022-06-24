using Los_Pollos_Hermanos.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Los_Pollos_Hermanos.Models
{
    public class User : IdentityUser<int>, IBaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual List<Menu> Menus { get; set; }
         
    }
}
