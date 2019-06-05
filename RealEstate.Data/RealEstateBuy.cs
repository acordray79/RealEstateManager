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

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public DateTime DateAvail { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool BuyFavorite { get; set; }

        [Required]
        public int RealEstatePropertyId { get; set; }

        public virtual RealEstateProperty Property { get; set; }

    }
}
