using System.Security.Cryptography;


namespace FlowBankAppLibrary.DataAccess;
public class SqlServerAccountData : IAccountData
{
   private readonly DataContext _dataContext;
   private readonly ITransactionData _transactionData;

   public SqlServerAccountData(DataContext dataContext, ITransactionData transactionData)
   {
      _dataContext = dataContext;
      _transactionData = transactionData;
   }

   public async Task CreateAccount(string userId)
   {
      try
      {
         var user = (await _dataContext.Users.SingleAsync(x => x.Id == userId));
         var userFullName = string.Format(user.LastName + " " + user.FirstName + " " + user.MiddleName);
         var rng = new RNGCryptoServiceProvider();
         var numberArray = new byte[5];
         //fills the array with random data values
         rng.GetBytes(numberArray);

         var accountId = BitConverter.ToUInt32(numberArray);
         Account account = new()
         {
            Id = accountId.ToString(),
            AccountType = "Savings",
            Balance = 0.0m,
            CurrencyType = "Naira",
            UserId = userId,
            UserFullName = userFullName
         };

         await _dataContext.Accounts.AddAsync(account);
         await _dataContext.SaveChangesAsync();
      }
      catch (Exception e)
      {
         throw e;
      }

   }
   
   public async Task<Account> GetAccountWithUserIdAsync(string userId)
   {
      var account = await _dataContext.Accounts.SingleOrDefaultAsync(x => x.UserId == userId);
      return account;
   }
   
   public async Task<Account> GetAccountWithAccountIdAsync(string id)
   {
      var account = await _dataContext.Accounts.SingleOrDefaultAsync(x => x.Id == id);
      return account;
   }
    
   public async Task<string> GetAccountNameWithAccountIdAsync(string id)
   {
      var account = await _dataContext.Accounts.SingleOrDefaultAsync(x => x.Id == id);
      return account is null ?  string.Empty: account.UserFullName;
   }


}
