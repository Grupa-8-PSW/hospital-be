using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class Ad
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public Ad(int id, string imagePath)
        {
            Id = id;
            ImagePath = imagePath;
        }
    }
}
