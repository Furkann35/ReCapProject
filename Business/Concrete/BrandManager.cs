using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class BrandManager : IBrandService
    {
        public List<Brand> GetCarsByBrandId()
        {
            throw new NotImplementedException();
        }
    }
}
