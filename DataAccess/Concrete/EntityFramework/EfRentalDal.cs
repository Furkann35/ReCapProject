using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using DataAccess.Concrete.Entityframework;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                IQueryable<RentalDetailDto> rentalDetails = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                                                            join c in context.Cars
                                                            on r.CarId equals c.CarId
                                                            join b in context.Brands
                                                            on c.BrandId equals b.BrandId
                                                            join cs in context.Customers
                                                            on r.CustomerId equals cs.Id
                                                            join user in context.Users
                                                            on cs.UserId equals user.Id
                                                            select new RentalDetailDto
                                                            {
                                                                CarId = c.CarId,
                                                                RentalId = r.RentalId,
                                                                BrandId = c.BrandId,
                                                                BrandName = b.BrandName,
                                                                CarName = c.CarName,
                                                                CompanyName = cs.CompanyName,
                                                                UserName = user.FirstName + " " + user.LastName,
                                                                RentDate = r.RentDate,
                                                                ReturnDate = r.ReturnDate
                                                            };
                return rentalDetails.ToList();
            }
        }

    }
}