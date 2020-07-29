namespace Business.Rules.Slips
{
    public class MembershipSlip : ISlip
    {
        public string Status { get; set; }
        public bool IsUpdated { get; internal set; }
    }
}