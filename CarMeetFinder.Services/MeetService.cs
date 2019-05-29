using CarMeetFinder.Data;
using CarMeetFinder.Models.MeetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Services
{
    public class MeetService
    {
        public readonly Guid _userID;

        public MeetService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateMeet(MeetCreate model)
        {
            var entity = new Meet()
            {
                OwnerID = _userID,
                LocationOfMeet = model.LocationOfMeet,
                DescriptionOfMeet = model.DescriptionOfMeet,
                DateOfMeet = model.DateOfMeet,
                DateCreated = DateTimeOffset.Now
            };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Meets.Add(entity);
                return ctx.SaveChanges() == 1;
            };
        }

        public IEnumerable<MeetListItem> GetMeets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Meets
                    .Select
                    (e => new MeetListItem
                    {
                        MeetID = e.MeetID,
                        LocationOfMeet = e.LocationOfMeet,
                        DescriptionOfMeet = e.DescriptionOfMeet,
                        DateOfMeet = e.DateOfMeet,
                        DateCreated = e.DateCreated
                    });
                
                return query.ToList();
            }
        }

        public MeetDetail GetMeetByID(int meetID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Meets.Single(e => e.MeetID == meetID);
                return new MeetDetail
                {
                    MeetID = entity.MeetID,
                    LocationOfMeet = entity.LocationOfMeet,
                    DescriptionOfMeet = entity.DescriptionOfMeet,
                    DateOfMeet = entity.DateOfMeet,
                    DateCreated = entity.DateCreated,

                };
            }
        }

        public bool UpdateMeet(MeetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Meets.Single
                    (e => e.MeetID == model.MeetID);
                {
                    entity.MeetID = model.MeetID;
                    entity.LocationOfMeet = model.LocationOfMeet;
                    entity.DescriptionOfMeet = model.DescriptionOfMeet;
                    entity.DateOfMeet = model.DateOfMeet;

                    return ctx.SaveChanges() == 1;
                }
            }
        }

        public bool DeleteMeet(int meetID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Meets
                    .Single(e => e.MeetID == meetID);
                ctx.Meets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
