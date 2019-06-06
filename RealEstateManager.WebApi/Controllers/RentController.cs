using Microsoft.AspNet.Identity;
using RealEstate.Models.RealEstateRent;
using RealEstate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealEstateManager.WebApi.Controllers
{
    [Authorize]
    public class RentController : ApiController
    {
        public IHttpActionResult GetAllRent()
        {
            RentService rentService = CreateRentService();
            var rentProperty = rentService.GetRent();
            return Ok(rentProperty);
        }

        public IHttpActionResult Get(int Id)
        {
            RentService rentService = CreateRentService();
            var rentProperty = rentService.GetRentById(Id);
                                   return Ok(rentProperty);
        }

        public IHttpActionResult Post(RentCreate rentCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRentService();

            if (!service.CreateRent(rentCreate))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(RentEdit editRent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRentService();

            if (!service.UpdateRent(editRent))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int Id)
        {
            var service = CreateRentService();

            if (!service.DeleteRent(Id))
                return InternalServerError();
            return Ok();
        }
        private RentService CreateRentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var rentService = new RentService(userId);
            return rentService;
        }
    }
}
