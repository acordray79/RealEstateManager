using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateRent
{
    public class RentDetail
    {
        [Key]
        public int RentId { get; set; }
        public int RealEstatePropertyId { get; set; }
        public string Available { get; set; }
        public double PricePerMonth { get; set; }
        public string Description { get; set; }
        public bool UtilitiesIncluded { get; set; }
        public bool PetsAllowed { get; set; }
        public bool IsRentFavorite { get; set; }

        public string RealEstatePropertyName { get; set; }
        public PropertyType PropertyType { get; set; }
        public string ImageLink { get; set; }
        public int SquareFootage { get; set; }
        public string RealEstateAddress { get; set; }
        public string RealEstateCity { get; set; }
        public string RealEstateState { get; set; }
        public int RealEstateZip { get; set; }
        public int Bedroom { get; set; }
        public bool HasBasement { get; set; }
        public bool HasPool { get; set; }
        public int Bathroom { get; set; }
        public int Stories { get; set; }
    }
}
