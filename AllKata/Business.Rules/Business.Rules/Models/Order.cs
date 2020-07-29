namespace Business.Rules.Models
{
    public class Order
    {
        public ISlip Slip { get; set; }
        public string Commission { get; set; }
    }
}