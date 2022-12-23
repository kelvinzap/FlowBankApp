namespace FlowBankAppLibrary.DataAccess;

public interface IUserData
{
   Task<UserDetailsDto> GetUserAsync(string userId);
}