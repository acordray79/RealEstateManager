using RealEstate.Data;
using RealEstate.Models.RealEstateRent;
using RealEstateManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public class RentService
    {
        private readonly Guid _userId;

        public RentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRent(RentCreate model)
        {
            var entity =
                new RealEstateRent()
                {
                    DateAvailable = model.DateAvailable,
                    PricePerMonth = model.PricePerMonth,
                    Description = model.Description,
                    UtilitiesIncluded = model.UtilitiesIncluded,
                    PetsAllowed = model.PetsAllowed,
                    IsRentFavorite = model.IsRentFavorite,
                    RealEstatePropertyId = model.RealEstatePropertyId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RealEstateRent.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RentListItem> GetRent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RealEstateRent
                    .Select(
                        e =>
                        new RentListItem
                        {
                            RentId = e.RentId,
                            DateAvailable = e.DateAvailable,
                            PricePerMonth = e.PricePerMonth,
                            Description = e.Description,
                            UtilitiesIncluded = e.UtilitiesIncluded,
                            PetsAllowed = e.PetsAllowed,
                            IsRentFavorite = e.IsRentFavorite,
                            RealEstatePropertyId = e.RealEstatePropertyId,
                            RealEstatePropertyName = e.RealEstateProperty.RealEstatePropertyName,
                            PropertyType = e.RealEstateProperty.PropertyType,
                            ImageLink = e.RealEstateProperty.ImageLink,
                            Stories = e.RealEstateProperty.Stories,
                            SquareFootage = e.RealEstateProperty.SquareFootage,
                            RealEstateAddress = e.RealEstateProperty.RealEstateAddress,
                            RealEstateCity = e.RealEstateProperty.RealEstateCity,
                            RealEstateState = e.RealEstateProperty.RealEstateState,
                            RealEstateZip = e.RealEstateProperty.RealEstateZip,
                            Bedroom = e.RealEstateProperty.Bedroom,
                            HasBasement = e.RealEstateProperty.HasBasement,
                            HasPool = e.RealEstateProperty.HasPool,
                            Bathroom = e.RealEstateProperty.Bathroom
                        }).ToArray();

                return query.ToArray();
            }
        }

        public RentDetail GetRentById(int rentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RealEstateRent
                    .Single(e => e.RentId == rentId);
                return
                    new RentDetail
                    {
                        RentId = entity.RentId,
                        DateAvailable = entity.DateAvailable,
                        PricePerMonth = entity.PricePerMonth,
                        Description = entity.Description,
                        UtilitiesIncluded = entity.UtilitiesIncluded,
                        PetsAllowed = entity.PetsAllowed,
                        IsRentFavorite = entity.IsRentFavorite,
                        RealEstatePropertyId = entity.RealEstatePropertyId,
                        RealEstatePropertyName = entity.RealEstateProperty.RealEstatePropertyName,
                        PropertyType = entity.RealEstateProperty.PropertyType,
                        ImageLink = entity.RealEstateProperty.ImageLink,
                        Stories = entity.RealEstateProperty.Stories,
                        SquareFootage = entity.RealEstateProperty.SquareFootage,
                        RealEstateAddress = entity.RealEstateProperty.RealEstateAddress,
                        RealEstateCity = entity.RealEstateProperty.RealEstateCity,
                        RealEstateState = entity.RealEstateProperty.RealEstateState,
                        RealEstateZip = entity.RealEstateProperty.RealEstateZip,
                        Bedroom = entity.RealEstateProperty.Bedroom,
                        HasBasement = entity.RealEstateProperty.HasBasement,
                        HasPool = entity.RealEstateProperty.HasPool,
                        Bathroom = entity.RealEstateProperty.Bathroom
                    };
            }
        }
        public bool UpdateRent(RentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RealEstateRent
                    .Single(e => e.RentId == model.RentId);
                entity.DateAvailable = model.DateAvailable;
                entity.PricePerMonth = model.PricePerMonth;
                entity.Description = model.Description;
                entity.UtilitiesIncluded = model.UtilitiesIncluded;
                entity.PetsAllowed = model.PetsAllowed;
                entity.IsRentFavorite = model.IsRentFavorite;
                entity.RealEstatePropertyId = model.RealEstatePropertyId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRent(int rentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RealEstateRent
                    .Single(e => e.RentId == rentId);

                ctx.RealEstateRent.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
