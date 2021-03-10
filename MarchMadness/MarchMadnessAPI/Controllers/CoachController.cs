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
    public class CoachController : ApiController
    {
        private CoachService CreateCoachService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var coachService = new CoachService(userId);
            return coachService;
        }
        public IHttpActionResult Get()
        {
            CoachService coachService = CreateCoachService();
            var coach = coachService.GetCoach();
            return Ok(coach);
        }
        public IHttpActionResult Coach(CoachCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCoachService();

            if (!service.CreateCoach(note))
                return InternalServerError();

            return Ok();
        }
    }
}
