using Business.Rules;
using Business.Rules.Payment;
using Business.Rules.Products;
using Business.Rules.Slips;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Test.Business.Rules
{
    [TestClass]
    public class PaymentTest
    {
        private IPayment _payment;

        [TestInitialize]
        public void Setup()
        {
            _payment = new VideoPayment();
        }

        [TestMethod]
        public void ShouldPayForLearningToSkiVideo()
        {
            var slip = _payment.Buy(new VideoProduct(){Name = "Learning to Ski" });
            Assert.IsNotNull(slip);
            Assert.IsTrue(slip.GetType() == typeof(VideoSlip));
            var slp = (VideoSlip)slip;
            Assert.IsTrue(slp.Name == "Learning to Ski");
            Assert.IsTrue(slp.FreeItem == "First Aid");
        }

        [TestMethod]
        public void ShouldPayForNotLearningToSkiVideo()
        {
            var slip = _payment.Buy(new VideoProduct() { Name = "ABC" });
            Assert.IsNotNull(slip);
            Assert.IsTrue(slip.GetType() == typeof(VideoSlip));
            var slp = (VideoSlip)slip;
            Assert.IsTrue(slp.Name == "ABC");
            Assert.IsFalse(slp.FreeItem == "First Aid");
        }


        [TestMethod]
        public void ShouldVideoIsNullReturnNull()
        {
            var slip = _payment.Buy(null);
            Assert.IsNull(slip);
        }
    }
}