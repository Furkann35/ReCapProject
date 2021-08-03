using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult CheckCreditCard(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(c => c.CardNumber == creditCard.CardNumber && c.CardYear == creditCard.CardYear && c.CardMonth == creditCard.CardMonth && c.CardCcv == creditCard.CardCcv && c.CardName == creditCard.CardName);
            if (result == null)
            {
                return new ErrorResult("kredi kartı bulunamadı");
            }
            else { return new SuccessResult("Kredi kartı doğrulandı");
            }

        }

        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id== id));
        }
    }
}
