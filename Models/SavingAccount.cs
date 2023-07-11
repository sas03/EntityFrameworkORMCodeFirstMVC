namespace EntityFrameworkMVC.Models
{
    public class SavingAccount
    {
        public Guid SavingAccountId { get; set; }
        public Double Amount { get; set; }
        public Double Rate { get; set; }
        public bool IsRatebyMonth { get; set; }
    }
}
