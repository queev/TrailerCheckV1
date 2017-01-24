using System;
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
        [DataType(DataType.Date)]
        public DateTime YearOfManufacture { get; set; }

        public string Stolen { get; set; }
    }
}
