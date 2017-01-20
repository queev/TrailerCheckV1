using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrailerCheckV1.Models
{
    public class Trailer
    {
        public int ID { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Product Group")]
        public string ProductGroup { get; set; }

        public string Model { get; set; }

        [Display(Name = "Year")]
        public DateTime YearOfManufacture { get; set; }

        public string Stolen { get; set; }
    }
}
