using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public Int64 CardNumber { get; set; }
        public int CardMonth { get; set; }
        public int CardYear { get; set; }
        public int CardCcv { get; set; }
        public string CardName { get; set; }

    }
}
