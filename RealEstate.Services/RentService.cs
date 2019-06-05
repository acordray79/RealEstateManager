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
                    Available = model.Available,
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
                            Available = e.Available,
                            PricePerMonth = e.PricePerMonth,
                            Description = e.Description,
                            UtilitiesIncluded = e.UtilitiesIncluded,
                            PetsAllowed = e.PetsAllowed,
                            IsRentFavorite = e.IsRentFavorite,
                            RealEstatePropertyId = e.RealEstatePropertyId
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
                        Available = entity.Available,
                        PricePerMonth = entity.PricePerMonth,
                        Description = entity.Description,
                        UtilitiesIncluded = entity.UtilitiesIncluded,
                        PetsAllowed = entity.PetsAllowed,
                        IsRentFavorite = entity.IsRentFavorite,
                        RealEstatePropertyId = entity.RealEstatePropertyId
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
                entity.Available = model.Available;
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
