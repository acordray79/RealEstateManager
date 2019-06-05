using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models.RealEstateRent
{
    public class RentEdit
    {
        public DateTime Available { get; set; }
        public int RentId { get; set; }
        public double PricePerMonth { get; set; }
        public string Description { get; set; }
        public bool UtilitiesIncluded { get; set; }
        public bool PetsAllowed { get; set; }

        public bool IsRestFavorite { get; set; }

        public int RealEstatePropertyID { get; set; }
    }
}
