using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateBuys
{
    public class BuyListItem
    {
        public int BuyId { get; set; }
        public int RealEstatePropertyId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM} {0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime DateAvail { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string RealEstatePropertyName { get; set; }
        public PropertyType PropertyType { get; set; }
        public string ImageLink { get; set; }
        public string RealEstateCity { get; set; }
        public string RealEstateState { get; set; }
        public int Bedroom { get; set; }
    }
}
