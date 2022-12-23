namespace FlowBankAppLibrary.DataAccess;

public interface IBankData
{
   Task<List<Bank>> GetAllBanksAsync();
   Task<Bank> GetBankAsync(string code);
}