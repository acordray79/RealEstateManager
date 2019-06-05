using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateProperty
{
    public class RealEstatePropertyUpdate
    {
        public int RealEstatePropertyId { get; set; }
        public string RealEstateProperyName { get; set; }
        public string ImageLink { get; set; }
        public int SquareFootage { get; set; }
        public string RealEstateAddress { get; set; }
        public string RealEstateCity { get; set; }
        public string RealEstateState { get; set; }
        public int RealEstateZip { get; set; }
        public PropertyType PropertyType { get; set; }
        public bool HasBasement { get; set; }
        public bool HasPool { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int Stories { get; set; }
    }
}
