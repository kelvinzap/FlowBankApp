namespace FlowBankAppLibrary.DataAccess;

public interface IAccountData
{
   Task CreateAccount(string userId);
   Task<Account> GetAccountWithUserIdAsync(string userId);
   Task<string> GetAccountNameWithAccountIdAsync(string id);
  
   Task<Account> GetAccountWithAccountIdAsync(string id);
}