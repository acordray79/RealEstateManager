using RealEstate.Data;
using RealEstate.Models.RealEstateProperty;
using RealEstateManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public class RealEstatePropertyService
    {
        private readonly Guid _userID;

        public RealEstatePropertyService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateRealEstateProperty(RealEstatePropertyCreate model)
        {
            var entity =
                new RealEstateProperty()
                {
                    RealEstatePropertyName = model.RealEstatePropertyName,
                    ImageLink = model.ImageLink,
                    SquareFootage = model.SquareFootage,
                    RealEstateAddress = model.RealEstateAddress,
                    RealEstateCity = model.RealEstateCity,
                    RealEstateState = model.RealEstateState,
                    RealEstateZip = model.RealEstateZip,
                    PropertyType = model.PropertyType,
                    HasBasement = model.HasBasement,
                    HasPool = model.HasPool,
                    Bedroom = model.Bedroom,
                    Bathroom = model.Bathroom,
                    Stories = model.Stories

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RealEstateProperty.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RealEstatePropertyListItem> GetRealEstateProperty()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RealEstateProperty
                        .Select(
                            e =>
                                new RealEstatePropertyListItem
                                {
                                    RealEstatePropertyId = e.RealEstatePropertyId,
                                    RealEstatePropertyName = e.RealEstatePropertyName,
                                    ImageLink = e.ImageLink,
                                    SquareFootage = e.SquareFootage,
                                    RealEstateAddress = e.RealEstateAddress,
                                    RealEstateCity = e.RealEstateCity,
                                    RealEstateState = e.RealEstateState,
                                    RealEstateZip = e.RealEstateZip,
                                    PropertyType = e.PropertyType,
                                    HasBasement = e.HasBasement,
                                    HasPool = e.HasPool,
                                    Bedroom = e.Bedroom,
                                    Bathroom = e.Bathroom,
                                    Stories = e.Stories
                                }
                             );
                return query.ToArray();
            }
        }

        public RealEstatePropertyDetail GetRealEstatePropertyById(int realEstatePropertyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RealEstateProperty
                        .Single(e => e.RealEstatePropertyId == realEstatePropertyId);
                return
                    new RealEstatePropertyDetail
                    {
                        RealEstatePropertyId = entity.RealEstatePropertyId,
                        RealEstatePropertyName = entity.RealEstatePropertyName,
                        ImageLink = entity.ImageLink,
                        SquareFootage = entity.SquareFootage,
                        RealEstateAddress = entity.RealEstateAddress,
                        RealEstateCity = entity.RealEstateCity,
                        RealEstateState = entity.RealEstateState,
                        RealEstateZip = entity.RealEstateZip,
                        PropertyType = entity.PropertyType,
                        HasBasement = entity.HasBasement,
                        HasPool = entity.HasPool,
                        Bedroom = entity.Bedroom,
                        Bathroom = entity.Bathroom,
                        Stories = entity.Stories
                    };
            }
        }

        public bool RealEstatePropertyUpdate(RealEstatePropertyUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RealEstateProperty
                        .Single(e => e.RealEstatePropertyId == model.RealEstatePropertyId);
                entity.RealEstatePropertyName = model.RealEstatePropertyName;
                entity.ImageLink = model.ImageLink;
                entity.SquareFootage = model.SquareFootage;
                entity.RealEstateAddress = model.RealEstateAddress;
                entity.RealEstateCity = model.RealEstateCity;
                entity.RealEstateState = model.RealEstateState;
                entity.RealEstateZip = model.RealEstateZip;
                entity.PropertyType = model.PropertyType;
                entity.HasBasement = model.HasBasement;
                entity.HasPool = model.HasPool;
                entity.Bedroom = model.Bedroom;
                entity.Bathroom = model.Bathroom;
                entity.Stories = model.Stories;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RealEstatePropertyDelete(int realEstatePropertyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RealEstateProperty
                        .Single(e => e.RealEstatePropertyId == realEstatePropertyId);

                ctx.RealEstateProperty.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
