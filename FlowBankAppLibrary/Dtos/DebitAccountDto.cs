namespace FlowBankAppLibrary.Dtos;

public class DebitAccountDto
{
   public string UserId{ get; set; }
   public string Code { get; set; }
   public long CreditAccount { get; set; }
   public string CreditAccountName { get; set; }
   public string SessionId { get; set; }
   public string Description { get; set; }
   public decimal Amount { get; set; }
}