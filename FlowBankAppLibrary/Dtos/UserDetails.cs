namespace FlowBankAppLibrary.Dtos;

public class UserDetails
{
   public string FullName { get; set; }
   public string Username { get; set; }
   public decimal Balance { get; set; }
   public string  FirstName { get; set; }
   public string  MiddleName { get; set; }
   public string  LastName { get; set; }
   public DateTime DateOfBirth { get; set; }
   public string Street { get; set; }
   public string City { get; set; }
   public string State { get; set; }
   public string ZipCode { get; set; }
   public string CountryOfResidence { get; set; }
   public string Nationality { get; set; }
   public double BVN { get; set; }
   public string Occupation { get; set; }
   public double NIN { get; set; }
   public DateTime DateOfRegistration { get; set; }
   public string Email { get; set; }
   public bool EmailCOnfirmed { get; set; } = false;
   public bool PhoneNumberComfirmed { get; set; } = false;
}