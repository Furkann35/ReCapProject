using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CarRentedCheck(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult RentalReturn(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (result==null)
            {
                return new ErrorResult();
            }
            else
            {
                foreach (var item in result)
                {
                    if (item.ReturnDate == null)
                    {
                        _rentalDal.Update(rental);
                        return new SuccessResult(Messages.RentalReturned);
                    }
                }
                return new ErrorResult();
            }
           
        }
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult CarRentedCheck(Rental rental)
        {
            var rentalledCars = _rentalDal.GetAll(r => r.CarId == rental.CarId && (r.ReturnDate > rental.RentDate))
                .Any();

            if (rentalledCars)
            {
                var rentalledCars2 = _rentalDal.GetAll(r => r.CarId == rental.CarId && (rental.ReturnDate < r.RentDate))
                    .Any();
                if (rentalledCars2)
                {
                    return new SuccessResult();
                }

                return new ErrorResult("araba kiralanmış hocam");
            }
            return new SuccessResult();
        }
    }
}
