using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodBank
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Email { get; set; } 
        
        public string ServerAddress { get; set; }
        public string Password { get; set; } = "unknown";

        public string APIKey { get; set; } = "unknown";

        public string Image { get; set; }

        public string MonthlySubscriptionRoutingKey { get; set; }

        public BloodBank(string name, string email, string serverAddress, string password, string aPIKey, string image)
        {
            Name = name;
            Email = email;
            ServerAddress = serverAddress;
            Password = password;
            APIKey = aPIKey;
            Image = image;
        }

        public BloodBank()
        {
        }
    }
}
