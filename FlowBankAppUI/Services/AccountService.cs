using FlowBankAppUI.Model;

namespace FlowBankAppUI.Services;

public class AccountService : IAccountService
{
   private readonly IAccountData _accountData;
   private readonly ITransactionData _transactionData;
   

   public AccountService(IAccountData accountData, ITransactionData transactionData)
   {
      _accountData = accountData;
      _transactionData = transactionData;
   }

   public async Task<bool> DebitUserAccount(DebitAccount model)
   {
      var userAccount = await _accountData.GetAccountWithUserIdAsync(model.UserId);
      var creditAccount = await _accountData.GetAccountWithAccountIdAsync(model.CreditAccount);

      if (userAccount is null)
         return false;

      if (creditAccount is null)
         return false;

      if (Convert.ToDecimal(model.Amount) is 0.0m or < 100)
         return false;

      if (userAccount.Balance < Convert.ToDecimal(model.Amount))
         return false;

      try
      {
         userAccount.Balance -= Convert.ToDecimal(model.Amount);
         creditAccount.Balance += Convert.ToDecimal(model.Amount);
         Transaction debitTransaction = new()
         {
            Amount = Convert.ToDecimal(model.Amount),
            Channel = "Online",
            CreditAccount = Convert.ToInt64(model.CreditAccount),
            CreditAccountName = model.CreditAccountName,
            DebitAccount = Convert.ToInt64(userAccount.Id),
            DebitAccountName = userAccount.UserFullName,
            Description = model.Description,
            DestinationInstitutionId = model.Code,
            Id = Guid.NewGuid().ToString(),
            SessionId = model.SessionId,
            TransactionType = "debit",
            UserId = model.UserId,
            NameEnquiryRef = "ref"
         };
         
         Transaction creditTransaction = new()
         {
            Amount = Convert.ToDecimal(model.Amount),
            Channel = "Online",
            CreditAccountName = model.CreditAccountName,
            CreditAccount = Convert.ToInt64(model.CreditAccount),
            DebitAccount = Convert.ToInt64(userAccount.Id),
            DebitAccountName = userAccount.UserFullName,
            Description = model.Description,
            DestinationInstitutionId = model.Code,
            Id = Guid.NewGuid().ToString(),
            SessionId = model.SessionId,
            TransactionType = "credit",
            UserId = creditAccount.UserId,
            NameEnquiryRef = "ref"
         };

         var successfulTransaction =
            await _transactionData.CreateDebitUserTransaction(debitTransaction, creditTransaction);

         return successfulTransaction.Success;
      }
      catch (Exception e)
      {
         return false;
      }
   }
}