using Business.Rules;
using Business.Rules.Payment;
using Business.Rules.Products;
using Business.Rules.Slips;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Test.Business.Rules
{
    [TestClass]
    public class MembershipPaymentTest
    {
        private IPayment _payment;

        [TestInitialize]
        public void Setup()
        {
            _payment = new MembershipPayment();
        }

        [TestMethod]
        public void ShouldActivateMembership()
        {
            var slip = _payment.Buy(new MembershipProduct());
            Assert.IsNotNull(slip);
            Assert.IsTrue(slip.GetType() == typeof(MembershipSlip));
            var slp = (MembershipSlip)slip;
            Assert.IsFalse(slp.IsUpdated);
            Assert.IsTrue(slp.Status == "Activated");
        }

        [TestMethod]
        public void ShouldUpgradeMemberInfoShip()
        {
            if (_payment is MembershipPayment payment)
            {
                var slip = payment.Upgrade(new MembershipProduct() { Name = "ABC", EMail = "abc@gamil.com" });
                Assert.IsNotNull(slip);
                Assert.IsTrue(slip.GetType() == typeof(MembershipSlip));
                var slp = (MembershipSlip)slip;
                Assert.IsTrue(slp.IsUpdated);
                Assert.IsTrue(slp.Status == "Activated");
            }
        }


        [TestMethod]
        public void ShouldMembershipIsNullReturnNull()
        {
            var slip = _payment.Buy(null);
            Assert.IsNull(slip);
        }

        [TestMethod]
        public void ShouldUpgradeMemberIsNullReturnNull()
        {
            if (_payment is MembershipPayment payment)
            {
                var slip = payment.Upgrade(null);
                Assert.IsNull(slip);
            }
        }
    }
}