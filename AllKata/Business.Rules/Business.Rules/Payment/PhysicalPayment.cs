using Business.Rules.Slips;

namespace Business.Rules.Payment
{
    public class PhysicalPayment : IPayment
    {
        public ISlip Buy(IProduct product)
        {
            if (product == null)
                return null;
            return new ShippingSlip()
            {
                Shipping = "501, Bangaluru",
                AgentCommission = "20"
            };
        }
    }
}