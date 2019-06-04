using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public enum PropertyType { Residential = 1, Commercial, Industrial, Land }
    public class RealEstateProperty
    {
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
