namespace EntityFrameworkMVC.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public String Name { get; set; }
        public ICollection<SavingAccount> SavingAccounts { get; set; }
    }
}
