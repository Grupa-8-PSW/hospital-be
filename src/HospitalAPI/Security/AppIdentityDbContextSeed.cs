using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace HospitalAPI.Security
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService <RoleManager<IdentityRole<int>>>();

            await roleManager.CreateAsync(new IdentityRole<int>("Patient"));
            await roleManager.CreateAsync(new IdentityRole<int>("Doctor"));
            await roleManager.CreateAsync(new IdentityRole<int>("Manager"));

            var patientUser = new User()
            {
                UserName = "patient",
                Email= "patient@email.com"
            };
            await userManager.CreateAsync(patientUser, "12345");
            await userManager.AddToRoleAsync(patientUser, "Patient");

            var doctorUser = new User()
            {
                UserName = "doctor",
                Email = "doctor@email.com"
            };
            await userManager.CreateAsync(doctorUser, "12345");
            await userManager.AddToRoleAsync(doctorUser, "Doctor");

            var managerUser = new User()
            {
                UserName = "manager",
                Email = "manager@email.com"
            };
            await userManager.CreateAsync(managerUser, "12345");
            await userManager.AddToRoleAsync(managerUser, "Manager");
        }
    }
}
