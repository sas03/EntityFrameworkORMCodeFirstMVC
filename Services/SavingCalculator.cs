using EntityFrameworkMVC.Models;

namespace EntityFrameworkMVC.Services
{
    public class SavingCalculator
    {
        public static Double Calcul(SavingAccount account)
        {
            int nbIteration = 3;
            if (account.IsRatebyMonth)
                nbIteration = nbIteration * 12;

            double res = account.Amount;
            for (int i = 0; i < nbIteration; i++)
            {
                res = res * (1 + account.Rate);
            }
            return Math.Round(res, 2);
        }
    }
}
