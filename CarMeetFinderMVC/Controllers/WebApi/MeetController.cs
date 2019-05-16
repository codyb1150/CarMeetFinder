using CarMeetFinder.Models.MeetModels;
using CarMeetFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarMeetFinderMVC.Controllers.WebApi
{
    [Authorize]
    [RoutePrefix("api/Meet")]
    public class MeetController : ApiController
    {
        private bool SetGoingState(int meetID, bool newState)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MeetService(userID);

            var detail = service.GetMeetByID(meetID);

            var updatedMeet = new MeetEdit
            {
                MeetID = detail.MeetID,
                DescriptionOfMeet = detail.DescriptionOfMeet,
                LocationOfMeet = detail.LocationOfMeet,
                IsGoing = newState
            };

            return service.UpdateMeet(updatedMeet);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetGoingState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetGoingState(id, false);
    }
}
