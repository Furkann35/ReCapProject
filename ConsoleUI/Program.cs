using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            var result = rentalService.GetRentalDetails();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.BrandName + rental.FirstName + rental.LastName);
            }
        }
    }
}