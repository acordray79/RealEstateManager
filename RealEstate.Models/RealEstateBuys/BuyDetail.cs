using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateBuys
{
    public class BuyDetail
    {
        public int BuyId { get; set; }
        public int RealEstatePropertyId { get; set; }
        public DateTime DateAvail { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
