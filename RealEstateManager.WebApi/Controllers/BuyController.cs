using Microsoft.AspNet.Identity;
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
        public class BuyController : ApiController
        {
            public IHttpActionResult GetAllRealEstateProperty()
            {
                //RealEstatePropertyService realEstatePropertyService = CreateRealEstatePropertyService();
                //var realEstateProperty = realEstatePropertyService.GetRealEstateProperty();
                //return Ok(realEstateProperty);

            BuyService buyService = CreateBuyPropertyService();
            var buyProperty = buyService.GetBuyListItems();
            return Ok(buyProperty);
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

            public IHttpActionResult Delete(int id)
            {
                var service = CreateRealEstatePropertyService();

                if (!service.RealEstatePropertyDelete(id))
                    return InternalServerError();

                return Ok();
            }

            //private RealEstatePropertyService CreateRealEstatePropertyService()
            //{
            //    var userId = Guid.Parse(User.Identity.GetUserId());
            //    var realEstatePropertyService = new RealEstatePropertyService(userId);
            //    return realEstatePropertyService;
            //}

            private BuyService CreateBuyPropertyService()
            {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var buyPropertyService = new BuyService(userId);
            return buyPropertyService;
            }
        }
    
}
