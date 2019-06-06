using Microsoft.AspNet.Identity;
using RealEstate.Models.RealEstateProperty;
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
    public class RealEstatePropertyController : ApiController
    {
        public IHttpActionResult GetAllRealEstateProperty()
        {
            RealEstatePropertyService realEstatePropertyService = CreateRealEstatePropertyService();
            var realEstateProperty = realEstatePropertyService.GetRealEstateProperty();
            return Ok(realEstateProperty);
        }

        public IHttpActionResult Get(int id)
        {
            RealEstatePropertyService realEstatePropertyService = CreateRealEstatePropertyService();
            var realEstateProperty = realEstatePropertyService.GetRealEstatePropertyById(id);
            return Ok(realEstateProperty);
        }

        public IHttpActionResult Post(RealEstatePropertyCreate realEstateProperty)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRealEstatePropertyService();

            if (!service.CreateRealEstateProperty(realEstateProperty))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(RealEstatePropertyUpdate realEstateProperty)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var servic = CreateRealEstatePropertyService();

            if (!servic.RealEstatePropertyUpdate(realEstateProperty))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRealEstatePropertyService();

            if (!service.RealEstatePropertyDelete(id))
                return InternalServerError();

            return Ok();
        }

        private RealEstatePropertyService CreateRealEstatePropertyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var realEstatePropertyService = new RealEstatePropertyService(userId);
            return realEstatePropertyService;
        }
    }
}
