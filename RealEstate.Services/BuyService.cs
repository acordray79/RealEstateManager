using RealEstate.Data;
using RealEstate.Models.RealEstateBuys;
using RealEstateManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public class BuyService
    {
        private readonly Guid _userId;

        public BuyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBuyProperty(BuyCreate model)
        {
            using (var db = new ApplicationDbContext())
            {
                var buyProperty = new RealEstateBuy()
                {
                    RealEstatePropertyId = model.RealEstatePropertyId,
                    DateAvail = model.DateAvail,
                    Price = model.Price,
                    Description = model.Description
                };

                db.RealEstateBuy.Add(buyProperty);
                return db.SaveChanges() == 1;
            }
        }


        public IEnumerable<BuyListItem> GetBuyListItems()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.RealEstateBuy
                    .Select(
                    e =>
                        new BuyListItem
                        {
                            BuyId = e.BuyId,
                            RealEstatePropertyId = e.RealEstatePropertyId,
                            DateAvail = e.DateAvail,
                            Price = e.Price,
                            Description = e.Description,
                            RealEstatePropertyName = e.Property.RealEstatePropertyName,
                            PropertyType = e.Property.PropertyType,
                            ImageLink = e.Property.ImageLink,
                            RealEstateCity = e.Property.RealEstateCity,
                            RealEstateState = e.Property.RealEstateState,
                            Bedroom = e.Property.Bedroom
                        });
                return query.ToArray();
            }
        }


        public BuyDetail GetBuyPropertyById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.RealEstateBuy.Single(s => s.BuyId == id);

                var model = new BuyDetail
                {
                    BuyId = entity.BuyId,
                    RealEstatePropertyId = entity.RealEstatePropertyId,
                    DateAvail = entity.DateAvail,
                    Price = entity.Price,
                    Description = entity.Description,
                    RealEstatePropertyName = entity.Property.RealEstatePropertyName,
                    PropertyType = entity.Property.PropertyType,
                    ImageLink = entity.Property.ImageLink,
                    SquareFootage = entity.Property.SquareFootage,
                    RealEstateAddress = entity.Property.RealEstateAddress,
                    RealEstateCity = entity.Property.RealEstateCity,
                    RealEstateState = entity.Property.RealEstateState,
                    RealEstateZip = entity.Property.RealEstateZip,
                    Bedroom = entity.Property.Bedroom,
                    HasBasement = entity.Property.HasBasement,
                    HasPool = entity.Property.HasPool,
                    Bathroom = entity.Property.Bathroom

                };
                return model;
            }
        }


        public bool EditBuyProperty(BuyEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.RealEstateBuy.Single(s => s.BuyId == model.BuyId);

                entity.RealEstatePropertyId = model.RealEstatePropertyId;
                entity.BuyId = model.BuyId;
                entity.DateAvail = model.DateAvail;
                entity.Price = model.Price;
                entity.Description = model.Description;
                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteBuyProperty(int propertyId)
        {
            using (var db = new ApplicationDbContext())
            {
                var e = db.RealEstateBuy.Single(s => s.BuyId == propertyId);

                db.RealEstateBuy.Remove(e);

                return db.SaveChanges() == 1;
            }
        }
    }
}
