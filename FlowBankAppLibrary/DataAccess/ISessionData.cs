namespace FlowBankAppLibrary.DataAccess;

public interface ISessionData
{
   Task<Session> GetSessionAsync(string id);
   Task<bool> CreateSession(Session session);
}