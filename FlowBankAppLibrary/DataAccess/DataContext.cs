using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowBankAppLibrary.DataAccess;

public class DataContext : IdentityDbContext<AspNetUser>
{
   public DataContext()
   {
   }
   public DataContext(DbContextOptions<DataContext> options)
      :base(options)
   {
   }
   
   protected override void OnConfiguring(DbContextOptionsBuilder options)
   {
      if (!options.IsConfigured)
      {
         options.UseSqlServer("Server=DESKTOP-KELVIN\\SQLEXPRESS;Database=FlowBankDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
      }
   }
   //public DbSet<AspNetUser> AspNetUsers { get; set; }
   public DbSet<Account> Accounts { get; set; }
   public DbSet<Session> Sessions { get; set; }
   public DbSet<Transaction> Transactions { get; set; }
   public DbSet<Bank> Banks { get; set; }
   
}