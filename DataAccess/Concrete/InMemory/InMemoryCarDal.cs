using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Abstract;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1,BrandId = 1,ColorId = 1,Description= "Tofaş",ModelYear= 1980,DailyPrice= 5000},
                new Car{CarId = 2,BrandId = 2,ColorId = 1,Description= "Bmw",ModelYear= 2015,DailyPrice= 250000},
                new Car{CarId = 3,BrandId = 3,ColorId = 1,Description= "Mercedes",ModelYear= 2016,DailyPrice= 300000},
                new Car{CarId = 4,BrandId = 4,ColorId = 1,Description= "Porsche",ModelYear= 2018,DailyPrice= 950000},
                new Car{CarId = 5,BrandId = 4,ColorId = 1,Description= "Porsche",ModelYear= 2018,DailyPrice= 950000},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.CarId == c.CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarsClickDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == c.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
