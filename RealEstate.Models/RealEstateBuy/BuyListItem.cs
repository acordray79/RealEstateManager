using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateBuy
{
    public class BuyListItem
    {
        public int BuyId { get; set; }
        public int RealEstatePropertyId { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int SquareFootage { get; set; }

        [Display(Name = "Date Available")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAvail { get; set; }
        public double Price { get; set; }
    }
}

