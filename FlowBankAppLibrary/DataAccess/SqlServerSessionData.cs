namespace FlowBankAppLibrary.DataAccess;

public class SqlServerSessionData : ISessionData
{
   private readonly DataContext _dataContext;

   public SqlServerSessionData(DataContext dataContext)
   {
      _dataContext = dataContext;
   }

   public async Task<Session> GetSessionAsync(string id)
   {
      return await _dataContext.Sessions.SingleOrDefaultAsync(x => x.Id == id);
   }

   public async Task<bool> CreateSession(Session session)
   {
      await _dataContext.Sessions.AddAsync(session);
      var success = await _dataContext.SaveChangesAsync();

      return success > 0;
   }
}