namespace FlowBankAppLibrary.DataAccess;

public class SqlServerTransactionData : ITransactionData
{
   private readonly DataContext _dataContext;

   public SqlServerTransactionData(DataContext dataContext)
   {
      _dataContext = dataContext;
   }

   public async Task<CreateTransactionDto> CreateDebitUserTransaction(Transaction debitTransaction, Transaction creditTransaction)
   {
      if (debitTransaction is null || creditTransaction is null)
         return new CreateTransactionDto
         {
            TransactionId = string.Empty
         };
      try
      {
       
         await _dataContext.Transactions.AddAsync(debitTransaction);
         await _dataContext.Transactions.AddAsync(creditTransaction);
         await _dataContext.SaveChangesAsync();
         return new CreateTransactionDto
         {
            Success = true
         };
      }
      catch (Exception e)
      {
         return new CreateTransactionDto
         {
            TransactionId = string.Empty
         };
      }
   }

   public async Task<CreateTransactionDto> CreateCreditUserTransaction(Transaction transaction)
   {
      if (transaction is null)
         return new CreateTransactionDto
         {
            TransactionId = string.Empty
         };
      try
      {
         await _dataContext.Transactions.AddAsync(transaction);
         await _dataContext.SaveChangesAsync();
         return new CreateTransactionDto
         {
            Success = true,
            TransactionId = transaction.Id
         };
      }
      catch (Exception e)
      {
         return new CreateTransactionDto
         {
            TransactionId = string.Empty
         };
      }
   }

   public async Task<List<Transaction>> GetUserTransactions(string id)
   {
      return await _dataContext.Transactions.Where(x => x.UserId == id).ToListAsync();
   }

}