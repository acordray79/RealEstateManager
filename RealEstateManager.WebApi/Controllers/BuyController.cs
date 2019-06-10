using Microsoft.AspNet.Identity;
using RealEstate.Models.RealEstateBuys;
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
            BuyService buyService = CreateBuyPropertyService();
            var buyProperty = buyService.GetBuyListItems();
            return Ok(buyProperty);
            }

            public IHttpActionResult Get(int id)
            {
                BuyService buyService = CreateBuyPropertyService();
                var buyProperty = buyService.GetBuyPropertyById(id);
                return Ok(buyProperty);
        }

            public IHttpActionResult Post(BuyCreate createBuyProperty)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateBuyPropertyService();

                if (!service.CreateBuyProperty(createBuyProperty))
                    return InternalServerError();

                return Ok();
            }

        public IHttpActionResult Put(BuyEdit editBuyProperty)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBuyPropertyService();

            if (!service.EditBuyProperty(editBuyProperty))
                return InternalServerError();
            return Ok();
        }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateBuyPropertyService();

                if (!service.DeleteBuyProperty(id))
                    return InternalServerError();

                return Ok();
            }

            private BuyService CreateBuyPropertyService()
            {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var buyPropertyService = new BuyService(userId);
            return buyPropertyService;
            }
        }
    
}
