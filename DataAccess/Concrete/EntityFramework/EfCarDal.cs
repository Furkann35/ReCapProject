using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
       
     

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result =
                             from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                              on car.BrandId equals br.BrandId
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             
                         


                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandName = br.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 Images = (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList()
                                 };

                return result.ToList();


            }
        }
    }
}
