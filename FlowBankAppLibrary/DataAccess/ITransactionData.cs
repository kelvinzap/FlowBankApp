namespace FlowBankAppLibrary.DataAccess;

public interface ITransactionData
{
   Task<CreateTransactionDto> CreateDebitUserTransaction(Transaction debitTransaction, Transaction creditTransaction);
   Task<CreateTransactionDto> CreateCreditUserTransaction(Transaction transaction);
   Task<List<Transaction>> GetUserTransactions(string id);
}