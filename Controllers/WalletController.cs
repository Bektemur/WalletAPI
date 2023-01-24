using Microsoft.AspNetCore.Mvc;
using WalletAPI.Interface;

namespace WalletAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IWalletService _walletService;
        private readonly ILogger<WalletController> _logger;
        public WalletController(ApplicationContext context, IWalletService walletService, ILogger<WalletController> logger)
        {
            _context = context;
            _walletService = walletService;
            _logger = logger;
        }

        [HmacAuthorize]
        [HttpGet("Check")]
        public IActionResult CheckAccount(string account)
        {
            _logger.LogInformation(account);
            var accounts = _context.Wallet.Where(v => v.Account == account).FirstOrDefault();
            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(new Response() { IsSuccess = true, Message = "Кошелек существует"});
        }
        [HmacAuthorize]
        [HttpPost("Replenishment")]
        public IActionResult ReplenishmentAccount(string account, double amount)
        {
            _logger.LogInformation(account, amount);
            var response = _walletService.ReplenishmentAccount(account, amount);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HmacAuthorize]
        [HttpGet("GetOperationCurrentMounth")]
        public IActionResult GetOperationCurrentMounth(DateTime currentDate)
        {
            try
            {
                _logger.LogInformation(currentDate.ToShortDateString());
                var current = new DateTime(currentDate.Year, currentDate.Month, 1);
                var accounts = _context.Operation.Where(v => v.Time >= current && v.Time <= currentDate);
                var amount = accounts.Sum(v => v.Amount);
                var count = accounts.Count();
                if (accounts == null)
                {
                    return NotFound();
                }
                return Ok(new GetCurrentOperationResponse { Amount = amount, Count = count, IsSuccess = true, Message = "Success" }); ;
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Error = ex.Message, IsSuccess = false, Message = ex.Message }) ;
            }
            
        }

        [HmacAuthorize]
        [HttpGet("GetBalance")]
        public IActionResult GetBalance(string account)
        {
            _logger.LogInformation(account);
            var accounts = _context.Wallet.Where(v => v.Account == account).FirstOrDefault();
            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(new Response() { IsSuccess = true, Message = "Баланс = " + accounts.Balance.ToString() });
        }

    }
}
