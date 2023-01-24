using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using WalletAPI.Interface;
using WalletAPI.Model;

namespace WalletAPI.Service
{
    public class HmacValidatorService : IHmacValidation
    {
        private readonly ApplicationContext _context;
        //private readonly Logger<HmacValidatorService> _logger;
        public HmacValidatorService(ApplicationContext context)
        {
            _context = context;
            //_logger = logger;
        }
        public bool Validation(string userId, string digest, string request)
        {
           // _logger.LogInformation(userId, digest, request);
            var hash = GetHashSha1(request);
            var client = GetCustomer(userId);
            if (hash.Equals(digest) && client != null)
            {
                return true;
            }
            return false;
        }
        
        private string GetHashSha1(string request)
        {
            if (request == null)
            {
                return string.Empty;
            }
            byte[] message = System.Text.Encoding.UTF8.GetBytes(request);
            byte[] hashValue = GetSha1(message);

            string hashString = string.Empty;
            foreach (byte x in hashValue)
            {
                hashString += string.Format("{0:x2}", x);
            }
            //_logger.LogInformation(hashString);
            return hashString;
        }
        private static byte[] GetSha1(byte[] message)
        {
            var hashString = HMACSHA1.Create();
            return hashString.ComputeHash(message);
        }
        private Customer? GetCustomer(string userId)
        {
            if (Int32.TryParse(userId, out int Id))
                return _context.Customer.Where(v => v.Id == Id).FirstOrDefault();
            return null;
        }
    }
}
