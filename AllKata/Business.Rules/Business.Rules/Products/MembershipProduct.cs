using System;
using Business.Rules.Payment;

namespace Business.Rules.Products
{
    public class MembershipProduct : IProduct
    {
        public string Name { get; set; }
        public string EMail { get; set; }
    }
}