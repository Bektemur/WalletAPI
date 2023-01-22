using Microsoft.AspNetCore.Mvc;

namespace WalletAPI.Interface
{
    public interface IWalletService
    {
        Response ReplenishmentAccount(string account, double amount);
    }
}
