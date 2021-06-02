using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using DataAccess.Concrete.Entityframework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var customerJoin = from c in context.Customers
                                   join u in context.Users on c.UserId equals u.Id
                                   select new CustomerDetailDto
                                   {
                                       Id = c.Id,
                                       FirstName = u.FirstName,
                                       LastName = u.LastName
                                   };
                var result = from r in context.Rentals
                             join u in customerJoin
                             on r.CustomerId equals u.Id
                             join b in context.Brands on r.CarId equals b.BrandId
                             select new RentalDetailsDto
                             {
                                 Id = r.RentalId,
                                 BrandName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }

}