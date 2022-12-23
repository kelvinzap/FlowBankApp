

namespace FlowBankAppLibrary.DataAccess;

public class SqlServerBankData : IBankData
{
   private readonly DataContext _dataContext;

   public SqlServerBankData(DataContext dataContext)
   {
      _dataContext = dataContext;
   }

   public async Task<List<Bank>> GetAllBanksAsync()
   {
      return await _dataContext.Banks.ToListAsync();
   }

   public async Task<Bank> GetBankAsync(string code)
   {
      return await _dataContext.Banks.SingleOrDefaultAsync(x => x.Code == code);
   }
}