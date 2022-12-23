using Microsoft.AspNetCore.Identity;

namespace FlowBankAppLibrary.Model;

public class AspNetUser : IdentityUser
{
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
}