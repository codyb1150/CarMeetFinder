using CarMeetFinder.Data;
using CarMeetFinder.Models;
using CarMeetFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMeetFinder.Services
{
    public class CarService
    {
        public readonly Guid _userID;

        public CarService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateCar(CarCreate model)
        {
            var entity = new Car()
            {
                OwnerID = _userID,
                Make = model.Make,
                VehicleModel = model.VehicleModel,
                Specifications = model.Specifications,
                Description = model.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cars.Add(entity);
                return ctx.SaveChanges() == 1;
            };
        }

        public IEnumerable<CarListItem> GetCars()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Cars
                    .Select
                    (e => new CarListItem
                    {
                        CarID = e.CarID,
                        Make = e.Make,
                        VehicleModel = e.VehicleModel,
                        Specifications = e.Specifications,
                        Description = e.Description
                    });
                return query.ToList();
            }
        }

        public CarDetail GetCarByID(int carID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cars.Single(e => e.CarID == carID && e.OwnerID == _userID);
                return new CarDetail
                {
                    CarID = entity.CarID,
                    Make = entity.Make,
                    VehicleModel = entity.VehicleModel,
                    Specifications = entity.Specifications,
                    Description = entity.Description
                };
            }
        }

        public bool UpdateCar(CarEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cars.Single
                    (e => e.CarID == model.CarID && e.OwnerID == _userID);
                {
                    entity.CarID = model.CarID;
                    entity.Make = model.Make;
                    entity.VehicleModel = model.VehicleModel;
                    entity.Specifications = model.Specifications;
                    entity.Description = model.Description;

                    return ctx.SaveChanges() == 1;
                }
            }
        }

        public bool DeleteCar(int carID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Cars
                    .Single(e => e.CarID == carID && e.OwnerID == _userID);

                ctx.Cars.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
