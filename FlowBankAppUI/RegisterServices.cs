using FlowBankAppUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowBankAppUI;

public static class RegisterServices
{
   public static void ConfigureServices(this  WebApplicationBuilder builder)
   {
      var connectionString = builder.Configuration.GetConnectionString("SqlServer");
      builder.Services.AddDbContext<DataContext>(options =>
         options.UseSqlServer(connectionString));

      builder.Services.AddTransient<IAccountData, SqlServerAccountData>();
      builder.Services.AddTransient<IBankData, SqlServerBankData>();
      builder.Services.AddTransient<ISessionData, SqlServerSessionData>();
      builder.Services.AddTransient<ITransactionData, SqlServerTransactionData>();
      builder.Services.AddTransient<IAccountService, AccountService>();
      builder.Services.AddTransient<IUserData, SqlServerUserData>();

   }
}
