using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules.Models;
using Business.Rules.Payment;
using Business.Rules.Products;

namespace Business.Rules
{
   public interface IPayment
    {
        ISlip Buy(IProduct physicalProduct);
    }
}
