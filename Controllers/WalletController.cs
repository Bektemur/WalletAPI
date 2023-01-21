using Microsoft.AspNetCore.Mvc;

namespace WalletAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public WalletController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Operation.ToList());
        }
    }
}
