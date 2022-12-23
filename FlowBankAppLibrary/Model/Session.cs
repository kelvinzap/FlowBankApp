using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowBankAppLibrary.Model;

public class Session
{
   [Key]
   public string Id { get; set; }

   public string UserId { get; set; }
   [ForeignKey(nameof(UserId))]
   public AspNetUser User { get; set; }

   public DateTime CreationDate { get; set; }
}