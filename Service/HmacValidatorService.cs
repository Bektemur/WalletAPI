using WalletAPI.Interface;

namespace WalletAPI.Service
{
    public class HmacValidatorService : IHmacValidation
    {
        private readonly ApplicationContext _context;
        public HmacValidatorService(ApplicationContext context)
        {
            _context = context;
        }
        public bool Validation(string userId, string digest)
        {
            return true;
        }
    }
}
