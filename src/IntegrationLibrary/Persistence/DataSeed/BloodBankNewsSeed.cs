using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Persistence.DataSeed
{
    public static class BloodBankNewsSeed
    {
        public static void SeedBloodBankNews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodBankNews>().HasData(
                new BloodBankNews("Zbog konstantnog manjka krvi u odnosu na potrebe (posebno tokom praznika)" +
                " i ovaj put organizujemo celodnevnu novogodisnju akciju davanja krvi. " +
                "Krv mozete dati 26. janura od 8 do 13 ili od 15 do 18 casova. Ne sumnjamo u vasu humanost", "Nestasica krvi", 1,
                "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/Blog_010620_Who_Can_Cant_Donate_Blood.png?alt=media&token=0c812e41-7775-4c6f-99e5-e1180d12411e", false, false, null, 1),
                new BloodBankNews("Prva ovogodisnja akcija davanja krvi bice realizovana u ponedeljak 09. januara od 8 do 12 casova. " +
                "Zapocnite godinu humanim gestom i pomozite onima koji vam to nikada ne mogu vratiti.", 
                "Novogodisnja akcija davanja krvi", 2, 
                "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/h3.jpg?alt=media&token=482263cb-3590-405f-9c1e-e1fcd46b5229", false, false, null, 2),
                new BloodBankNews("U ponedeljak, 05. decembra, od 8 do 12 casova realizuje se akcija " +
                "dobrovoljnog davanja krvi u prostorijama Doma zdravlja. Kako je neuporedivo lepsi osecaj pomagati nego cekati " +
                "pomoc od nekog pozivamo vas da i ovoga puta pokazete svoju humanost i spasete do tri zivota. ", "Nova akcija doniranja", 3, 
                "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/h4.jpeg?alt=media&token=5b420fc6-e490-453c-afce-5d57241eda35", false, false, null, 3),
                new BloodBankNews("Vreme je novogodisnjeg darivanja. Darujte zivot na jednoj od dve akcije davanja krvi tokom sledece sedmice.  " +
                "\r\nPonedeljak 20. ili cetvrtak 23. decembar u istom terminu - od 16 do 19 casova", "Hitno potrebna krv!", 4,
                "https://firebasestorage.googleapis.com/v0/b/isapsw-6ef61.appspot.com/o/cartoon-blood-donation-background_52683-70799.jpg?alt=media&token=9aacb9e0-f633-4c89-9c19-ae731c3e7657", false, false, null, 4)
            );
        }
    }
}
