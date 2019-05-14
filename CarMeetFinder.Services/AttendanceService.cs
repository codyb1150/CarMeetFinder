using CarMeetFinder.Data;
using CarMeetFinder.Models.AttendanceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Services
{
    public class AttendanceService
    {
        public readonly Guid _userID;

        public AttendanceService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateAttendance(AttendanceCreate model)
        {
            var entity = new Attendance()
            {
                OwnerID = _userID,
                CarID = model.CarID,
                MeetID = model.MeetID,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attendances.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<CarSelect> GetCarSelectList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<CarSelect> carSelectItems = new List<CarSelect>();
                List<Car> listOfOwnedCars =
                    ctx
                        .Cars
                        .ToList();

                foreach (Car car in listOfOwnedCars)
                {
                    Member member = ctx.Members.Find(car.MemberID);

                    CarSelect newSelectItem = new CarSelect
                    {
                        CarID = car.CarID,
                        DisplayMember = $"{member.FullName} {car.Make}"
                    };
                    carSelectItems.Add(newSelectItem);
                }
                return carSelectItems;
            }
        }

        public List<MeetSelect> GetMeetSelectList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<MeetSelect> meetSelectItems = new List<MeetSelect>();
                List<Meet> listOfMeets = ctx.Meets.ToList();

                foreach (Meet meet in listOfMeets)
                {
                    MeetSelect newSelectItem = new MeetSelect
                    {
                        MeetID = meet.MeetID,
                        LocationOfMeet = meet.LocationOfMeet
                    };
                    meetSelectItems.Add(newSelectItem);
                }
                return meetSelectItems;
            }
        }

        public List<Meet> GetMeetList()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Meets.ToList();
            }
        }

        public List<Car> GetCarList()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Cars.ToList();
            }
        }


        public IEnumerable<AttendanceListItem> GetAttendance()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Attendances
                    .Select
                    (e => new AttendanceListItem
                    {
                        AttendanceID = e.AttendanceID,
                        CarID = e.CarID,
                        MeetID = e.MeetID,

                        Car = e.Car,
                        Meet = e.Meet

                    }).ToList();

                return query;
            }
        }

        public AttendanceListItem GetAttendanceByID(int attendanceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Attendances.Single(e => e.AttendanceID == attendanceID && e.OwnerID == _userID);
                return new AttendanceListItem
                {
                    AttendanceID = entity.AttendanceID,
                    CarID = entity.CarID,
                    MeetID = entity.MeetID,
                };
            }
        }

        public bool UpdateAttendance(AttendanceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Attendances.Single
                    (e => e.AttendanceID == model.AttendanceID && e.OwnerID == _userID);
                {
                    entity.AttendanceID = model.AttendanceID;
                    entity.CarID = model.CarID;
                    entity.MeetID = model.MeetID;

                    return ctx.SaveChanges() == 1;
                }
            }
        }

        public bool DeleteAttendance(int attendanceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Attendances
                    .Single(e => e.AttendanceID == attendanceID && e.OwnerID == _userID);

                ctx.Attendances.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

