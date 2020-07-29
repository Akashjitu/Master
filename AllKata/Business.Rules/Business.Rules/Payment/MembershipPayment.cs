using Business.Rules.Products;
using Business.Rules.Slips;

namespace Business.Rules.Payment
{
    public class MembershipPayment : IPayment
    {
        public ISlip Buy(IProduct product)
        {
            if (product == null)
                return null;
            return new MembershipSlip()
            {
                Status = "Activated",
                IsUpdated = false
            };
        }

        public ISlip Upgrade(MembershipProduct product)
        {
            if (product == null)
                return null;
            return new MembershipSlip()
            {
                Status = "Activated",
                IsUpdated = true
            };
        }
    }
}