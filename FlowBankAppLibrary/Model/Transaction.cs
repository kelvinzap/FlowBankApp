using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowBankAppLibrary.Model;

public class Transaction
{
   [Key]
   public string Id { get; set; }
   public string Description { get; set; }
   public DateTime DateOfTransaction { get; set; } = DateTime.UtcNow;
   [Column(TypeName = "decimal(18,2)")]
   public decimal Amount { get; set; }
   public string TransactionType { get; set; }
   public string DestinationInstitutionId { get; set; }
   public long DebitAccount { get; set; }
   public long CreditAccount { get; set; }
   public string DebitAccountName { get; set; }
   public string CreditAccountName { get; set; }
   public string NameEnquiryRef { get; set; }
   public string Channel { get; set; }
   public string UserId { get; set; }
   public string SessionId { get; set; }
}