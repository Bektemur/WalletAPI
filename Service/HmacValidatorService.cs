using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using WalletAPI.Interface;
using WalletAPI.Model;
using static System.Net.Mime.MediaTypeNames;

namespace WalletAPI.Service
{
    public class HmacValidatorService : IHmacValidation
    {
        private readonly ApplicationContext _context;
        public HmacValidatorService(ApplicationContext context)
        {
            _context = context;
        }
        public bool Validation(string userId, string digest, string request)
        {
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
            byte[] message = System.Text.Encoding.ASCII.GetBytes(request);
            byte[] hashValue = GetSha1(message);

            string hashString = string.Empty;
            foreach (byte x in hashValue)
            {
                hashString += string.Format("{0:x2}", x);
            }

            return hashString;
        }
        private static byte[] GetSha1(byte[] message)
        {
            var hashString = SHA1.Create();
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
