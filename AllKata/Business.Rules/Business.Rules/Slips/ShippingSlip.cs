namespace Business.Rules.Slips
{
    public class ShippingSlip : ISlip
    {
        public string AgentCommission { get; set; }
        public string Shipping { get; internal set; }
    }
}