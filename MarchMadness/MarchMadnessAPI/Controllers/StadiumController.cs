using MarchMadness.Models;
using MarchMadness.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarchMadnessAPI.Controllers
{
    [Authorize]
    public class StadiumController : ApiController
    {
        public IHttpActionResult Get()
        {
            StadiumService stadiumService = CreateStadiumService();
            var stadium = stadiumService.GetStadium();
            return Ok(stadium);
        }
        public IHttpActionResult Post(StadiumCreate stadium)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStadiumService();

            if (!service.CreateStadium(stadium))
                return InternalServerError();

            return Ok();
        }
        private StadiumService CreateStadiumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var stadiumService = new StadiumService(userId);
            return stadiumService;
        }
    }
}
