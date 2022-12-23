using System.ComponentModel.DataAnnotations;

namespace FlowBankAppUI.Model;

public class DebitAccount
{
   public string UserId{ get; set; }
   [Required]
   public string Code { get; set; }
   [Required]
   [Display(Name = "Account Number")]
   public string CreditAccount { get; set; }
   public string CreditAccountName { get; set; }
   public string SessionId { get; set; }
   [Required]
   [Display(Name = "Narration")]
   public string Description { get; set; }
   [Required]
   public string Amount { get; set; }
   
   
}