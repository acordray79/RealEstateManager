using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class RealEstateRent
    {
        [Key]
        public int RentId { get; set; }

        public Guid OwnerId { get; set; }
        public DateTime Available { get; set; }

        public double PricePerMonth { get; set; }

        public string Description { get; set; }

        public bool UtilitiesIncluded { get; set; }
        public bool PetsAllowed { get; set; }

        public bool IsRentFavorite { get; set; }

        public int RealEstatePropertyID { get; set; }
        public virtual RealEstateProperty RealEstateProperty { get; set; }

    }
}
