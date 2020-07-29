using Business.Rules;
using Business.Rules.Payment;
using Business.Rules.Products;
using Business.Rules.Slips;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Test.Business.Rules
{
    [TestClass]
    public class BookPaymentTest
    {
        private IPayment _payment;

        [TestInitialize]
        public void Setup()
        {
            _payment = new BookPayment();
        }

        [TestMethod]
        public void ShouldCreateBook()
        {
            var ship = _payment.Buy(new BookProduct() { Name = "Harry Potter" });

            Assert.IsNotNull(ship);
            Assert.IsTrue(ship.GetType() == typeof(BookRoyaltyDepartmentSlip));
            var sip = (BookRoyaltyDepartmentSlip)ship;

            Assert.IsFalse(string.IsNullOrEmpty(sip.Shipping));
            Assert.IsTrue(sip.Shipping == "501,Bangaluru");
            Assert.IsTrue(sip.DuplicateSlip == "501, Bangaluru");
            Assert.IsFalse(string.IsNullOrEmpty(sip.AgentCommission));
            Assert.IsTrue(sip.AgentCommission == "20");
        }

        [TestMethod]
        public void ShouldCreatBookIsNullReturnNull()
        {
            var ship = _payment.Buy(null);
            Assert.IsNull(ship);
        }
    }
}