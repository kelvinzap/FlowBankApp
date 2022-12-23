using System.ComponentModel.DataAnnotations;

namespace FlowBankAppLibrary.Model;

public class Bank
{
   [Key]
   public string Id { get; set; }
   public string Name { get; set; }
   public string Code { get; set; }

}