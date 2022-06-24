using Microsoft.AspNetCore.Identity;

namespace Los_Pollos_Hermanos.Helpers.Seed
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole()
        {

        }
        public AppRole(string roleName)
        {
            Name = roleName;
            NormalizedName = roleName.ToUpper();
        }

        public string Name { get; }
        public string NormalizedName { get; }
    }
}
