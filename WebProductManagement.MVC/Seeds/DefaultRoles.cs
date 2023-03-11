using Microsoft.AspNetCore.Identity;
using WebProductManagement.MVC.Constants;
using System.Threading.Tasks;

namespace WebProductManagement.MVC.Seeds
{
    public static class DefaultRoles  // Use this class to create default role
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}