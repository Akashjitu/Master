using System;
using Business.Rules.Models;
using Business.Rules.Slips;

namespace Business.Rules.Payment
{
    public class VideoPayment : IPayment
    {
        public ISlip Buy(IProduct product)
        {
            if (product == null)
                return null;

            var slip = new VideoSlip()
            {
                Name = product.Name,
                FreeItem = string.Empty
            };
            if (product.Name == "Learning to Ski")
                slip.FreeItem = "First Aid";

            return slip;
        }
    }
}