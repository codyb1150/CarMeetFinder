using CarMeetFinder.Data;
using CarMeetFinder.Models.MemberModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Services
{
    public class MemberService
    {
        public readonly Guid _userID;

        public MemberService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateMember(MemberCreate model)
        {
            var entity = new Member()
            {
                OwnerID = _userID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location,
                FullName = $"{model.FirstName} {model.LastName}"

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Members.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MemberListItem> GetMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Members
                    .Select
                    (e => new MemberListItem
                    {
                        MemberID = e.MemberID,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        FullName = e.FullName,
                        Location = e.Location
                    }).ToList();
                foreach (var member in query)
                {
                    member.FullName = $"{member.FirstName} {member.LastName}";
                }
                return query;
            }
        }

        public MemberDetail GetMemberByID(int memberID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Members.Single(e => e.MemberID == memberID && e.OwnerID == _userID);
                return new MemberDetail
                {
                    MemberID = entity.MemberID,
                    FullName = $"{entity.FirstName} {entity.LastName}",
                    Location = entity.Location
                };
            }
        }

        public bool UpdateMember(MemberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Members.Single
                    (e => e.MemberID == model.MemberID && e.OwnerID == _userID);
                {
                    entity.MemberID = model.MemberID;
                    entity.FirstName = model.FirstName;
                    entity.LastName = model.LastName;
                    entity.Location = model.Location;

                    return ctx.SaveChanges() == 1;
                }
            }
        }

        public bool DeleteMember(int memberID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity  = ctx.Members.Single(e => e.MemberID == memberID && e.OwnerID == _userID);

                ctx.Members.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
