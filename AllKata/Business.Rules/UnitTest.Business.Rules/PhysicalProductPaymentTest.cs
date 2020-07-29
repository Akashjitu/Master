using Business.Rules;
using Business.Rules.Payment;
using Business.Rules.Products;
using Business.Rules.Slips;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Test.Business.Rules
{
    [TestClass]
    public class PhysicalProductPaymentTest
    {
        private IPayment _payment;

        [TestInitialize]
        public void Setup()
        {
            _payment = new PhysicalPayment();
        }

        [TestMethod]
        public void ShouldGeneratePackingSlipForShippingPhysicalProduct()
        {
            var slip = _payment.Buy(new PhysicalProduct() { Name = "Laptop" });

            Assert.IsNotNull(slip);
            Assert.IsTrue(slip.GetType() == typeof(ShippingSlip));
            var sip = (ShippingSlip)slip;

            Assert.IsFalse(string.IsNullOrEmpty(sip.Shipping));
            Assert.IsTrue(sip.Shipping == "501, Bangaluru");
            Assert.IsFalse(string.IsNullOrEmpty(sip.AgentCommission));
            Assert.IsTrue(sip.AgentCommission == "20");
        }

        [TestMethod]
        public void ShouldGeneratePackingSlipIsNullReturnNull()
        {
            var slip = _payment.Buy(null);
            Assert.IsNull(slip);
        }
    }
}