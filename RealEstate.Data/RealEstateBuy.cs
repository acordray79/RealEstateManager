using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class RealEstateBuy
    {
        [Key]
        public int BuyId { get; set; }


        public Guid OwnerId { get; set; }


        public DateTime DateAvail { get; set; }


        public double Price { get; set; }


        public string Description { get; set; }

        [DefaultValue(false)]
        public bool? BuyFavorite { get; set; }


        public int RealEstatePropertyId { get; set; }

        public virtual RealEstateProperty Property { get; set; }

    }
}
