using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowBankAppLibrary.Model;
public class Account
{
   [Key]
   public string Id{ get; set; } 
    
   public string UserId { get; set; }
    
   [ForeignKey(nameof(UserId))]
   public AspNetUser User { get; set; }

   public string UserFullName { get; set; }
    
   public string AccountType { get; set; }
    
   public string CurrencyType { get; set; }
   public DateTime CreationDate { get; set; } = DateTime.UtcNow;
   [Column(TypeName = "decimal(18,2)")]
   public decimal Balance { get; set; }
}
