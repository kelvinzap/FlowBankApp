using FlowBankAppUI.Model;

namespace FlowBankAppUI.Services;

public interface IAccountService
{
   Task<bool> DebitUserAccount(DebitAccount model);
}