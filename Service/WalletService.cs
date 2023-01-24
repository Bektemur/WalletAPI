
using Microsoft.AspNetCore.Mvc;
using WalletAPI.Interface;
using WalletAPI.Model;

namespace WalletAPI.Service
{
    public class WalletService : IWalletService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;
        public WalletService(ApplicationContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public Response ReplenishmentAccount(string account, double amount)
        {
            try
            {
                _logger.LogInformation(account, amount);
                double balance = 0;
                if (string.IsNullOrWhiteSpace(account))
                {
                    return new Response { IsSuccess = false, Message = "Счет пустой" };
                }
                if (amount <= 0)
                {
                    return new Response { IsSuccess = false, Message = "Введите другую сумму" };
                }
                var wallet = _context.Wallet.Where(v => v.Account == account).FirstOrDefault();
                if (wallet == null)
                {
                    return new Response { IsSuccess = false, Message = "Нет клиента с кошельком " + account }; ;
                }
                var customer = _context.Customer.Where(v => v.Id == wallet.CustomerId).FirstOrDefault();
                if (customer == null)
                {
                    return new Response { IsSuccess = false, Message = "Нет клиента " };
                }
                balance = wallet.Balance + amount;
                if ((wallet.IsIdentified && balance <= 100000) || (!wallet.IsIdentified && balance <= 10000))
                {
                    _context.Operation.Add(new Operation() { Amount = amount, WalletId = wallet.Id, Time = DateTime.UtcNow });
                    wallet.Balance = balance;
                    _context.Wallet.Update(wallet);
                    _context.SaveChanges();
                    return new Response { IsSuccess = true, Message = "Кошелёк успешно пополнен! Ваш баланс: " + wallet.Balance };
                }
                else
                {
                    if(wallet.IsIdentified)
                    {
                        return new Response { IsSuccess = false, Message = "Максимальный баланс составляет 100 000" };
                    }
                    else
                    {
                        return new Response { IsSuccess = false, Message = "Максимальный баланс составляет 10 000" };
                    }
                }
                
            }
            catch(Exception ex)
            {
                return new Response { IsSuccess = false, Message = ex.Message};
            }
            
        }
    }
}
