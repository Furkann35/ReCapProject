﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (result==null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                foreach (var item in result)
                {
                    if (item.ReturnDate==null)
                    {
                        return new ErrorResult(Messages.RentalNotAdded);
                    }
                }
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
    
        }

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
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
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

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
