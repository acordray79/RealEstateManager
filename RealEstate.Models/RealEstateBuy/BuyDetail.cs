using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateBuy
{
    public class BuyDetail
    {
        public int BuyId { get; set; }
        public int RealEstatePropertyId { get; set; }
        public double Price { get; set; }

        [Display(Name = "Date Available")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy} ", ApplyFormatInEditMode = true)]
        public DateTime DateAvail { get; set; }
        public string Description { get; set; }
    }
}
