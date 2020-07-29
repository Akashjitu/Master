namespace Business.Rules.Slips
{
    public class BookRoyaltyDepartmentSlip : ISlip
    {
        public string Shipping { get; set; }
        public string DuplicateSlip { get; set; }
        public string AgentCommission { get; set; }
    }
}