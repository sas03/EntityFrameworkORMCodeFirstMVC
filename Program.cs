using EntityFrameworkMVC.Models;
using EntityFrameworkMVC.Repositories;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        InitDb();

        app.Run();
    }
    public static void InitDb()
    {
        using (var context = new SavingContext())
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            List<SavingAccount> Accounts = new List<SavingAccount>
            {
                new SavingAccount() {Amount = 2000000, Rate = 0.05, IsRatebyMonth = true },
                new SavingAccount() {Amount = 250000, Rate = 0.15, IsRatebyMonth = false },
                new SavingAccount() {Amount = 10000000, Rate = 0.02, IsRatebyMonth = false },
            };

            Person person = new Person() { Name = "Mr Person", SavingAccounts = Accounts };

            context.Add(person);
            context.SaveChanges();
        }
    }
}
