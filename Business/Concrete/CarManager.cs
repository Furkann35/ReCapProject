using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
        }

      
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        //public List<Car> GetById(int CategoryId)
        //{
        //    return _carDal.GetById(CategoryId);

        //}

        public List<Car> GetcarsByBrandId(int BrandId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetcarsByColorId(int ColorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
