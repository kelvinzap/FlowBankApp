namespace FlowBankAppLibrary.DataAccess;

public class SqlServerUserData : IUserData
{
   private readonly DataContext _dataContext;
   private readonly IAccountData _accountData;
   

   public SqlServerUserData(DataContext dataContext, IAccountData accountData)
   {
      _dataContext = dataContext;
      _accountData = accountData;
   }

   public async Task<UserDetailsDto> GetUserAsync(string userId)
   {
      var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == userId);

      if (user is null)
         return new UserDetailsDto
         {
            Details = new UserDetails()
         };
         
      var userAccount = await _accountData.GetAccountWithUserIdAsync(user.Id);
      
      if (userAccount is null)
         return new UserDetailsDto
         {
            Details = new UserDetails()
         };

      return new UserDetailsDto
      {
         Success = true,
         Details = new UserDetails
         {
            Username = user.UserName,
            FullName = userAccount.UserFullName,
            Balance = userAccount.Balance,
            BVN = user.BVN,
            City = user.City,
            CountryOfResidence = user.CountryOfResidence,
            DateOfBirth = user.DateOfBirth,
            DateOfRegistration = user.DateOfRegistration,
            Email = user.Email,
            EmailCOnfirmed = user.EmailConfirmed,
            Nationality = user.Nationality,
            Occupation = user.Occupation,
            State = user.State,
            Street = user.Street,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            ZipCode = user.ZipCode,
            PhoneNumberComfirmed = user.PhoneNumberConfirmed,
            NIN = user.NIN
         }
      };

   }
   
}