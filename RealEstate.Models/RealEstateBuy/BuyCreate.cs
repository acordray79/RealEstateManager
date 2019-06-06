using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateBuy
{
    public class BuyCreate
    {
        public int RealEstatePropertyId { get; set; }

        [Display(Name = "Date Available")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAvail { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

    }
}
