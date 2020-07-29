using Business.Rules.Slips;

namespace Business.Rules.Payment
{
    public class BookPayment : IPayment
    {
        public ISlip Buy(IProduct product)
        {
            if (product == null)
                return null;
            return new BookRoyaltyDepartmentSlip()
            {
                DuplicateSlip = "501, Bangaluru",
                Shipping = "501,Bangaluru",
                AgentCommission = "20"
            };
        }
    }
}