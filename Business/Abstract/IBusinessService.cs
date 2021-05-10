using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface  IBusinessService
    {
        List<Car> GetAll();

        List<Car> GetById(int CategoryId);

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
