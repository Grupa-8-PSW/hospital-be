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

            //AspNetUsers za inicijalne pacijente
            var patient1 = new User()
            {
                UserName = "peraperic",
                Email = "peraperic@gmail.com"
            };
            await userManager.CreateAsync(patient1, "12345");
            await userManager.AddToRoleAsync(patient1, "Patient");

            var patient2 = new User()
            {
                UserName = "markomarkovic",
                Email = "markomarkovic@gmail.com"
            };
            await userManager.CreateAsync(patient2, "12345");
            await userManager.AddToRoleAsync(patient2, "Patient");

            var patient3 = new User()
            {
                UserName = "dusanbaljinac",
                Email = "dusanbaljinac@gmail.com"
            };
            await userManager.CreateAsync(patient3, "12345");
            await userManager.AddToRoleAsync(patient3, "Patient");

            var patient4= new User()
            {
                UserName = "slobodanradulovic",
                Email = "slobodanradulovic@gmail.com"
            };
            await userManager.CreateAsync(patient4, "12345");
            await userManager.AddToRoleAsync(patient4, "Patient");
        }
    }
}
