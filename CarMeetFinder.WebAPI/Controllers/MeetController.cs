using CarMeetFinder.Models;
using CarMeetFinder.Models.MeetModels;
using CarMeetFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarMeetFinder.WebAPI.Controllers
{
    [Authorize]
    public class MeetController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            MeetService meetService = CreateMeetService();
            var meet = meetService.GetMeets();
            return Ok(meet);
        }

        public IHttpActionResult Get(int id)
        {
            MeetService meetService = CreateMeetService();
            var meet = meetService.GetMeetByID(id);
            return Ok(meet);
        }

        public IHttpActionResult Post(MeetCreate meet)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateMeetService();

            if (!service.CreateMeet(meet)) return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(MeetEdit meet)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateMeetService();

            if (!service.UpdateMeet(meet)) return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMeetService();

            if (!service.DeleteMeet(id)) return InternalServerError();

            return Ok();
        }

        private MeetService CreateMeetService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var meetService = new MeetService(userID);
            return meetService;
        }
    }
}
