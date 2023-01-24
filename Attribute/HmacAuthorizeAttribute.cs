using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Text;
using WalletAPI.Interface;
using WalletAPI.Service;

namespace WalletAPI
{

    public class HmacAuthorizeAttribute : TypeFilterAttribute
    {
        public HmacAuthorizeAttribute() : base(typeof(HmacAuthorizeFilter))
        {
        }
    }
    public class HmacAuthorizeFilter : IAuthorizationFilter 
    {
        private readonly IHmacValidation _hmacValidation;
        private readonly ILogger<HmacAuthorizeFilter> _logger;
        public HmacAuthorizeFilter(IHmacValidation hmacValidation, ILogger<HmacAuthorizeFilter> logger)
        {
            _hmacValidation = hmacValidation;
            _logger = logger;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = ReadBodyAsString(context.HttpContext.Request);
            _logger.LogInformation(request);
            if (!context.HttpContext.Request.Headers.ContainsKey("X-Digest") && !context.HttpContext.Request.Headers.ContainsKey("X-UserId"))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                context.HttpContext.Request.Headers.TryGetValue("X-Digest", out var headerDigestValue);
                context.HttpContext.Request.Headers.TryGetValue("X-UserId", out var headerUserIdValue);
                var isValid = _hmacValidation.Validation(headerUserIdValue.ToString(), headerDigestValue.ToString(), request);
                if (!isValid)
                {
                    context.Result = new UnauthorizedResult();
                }
                
            }
           
        }
        private string ReadBodyAsString(HttpRequest request)
        {
            request.EnableBuffering();

            using (StreamReader reader = new (request.Body))
            {
                    string text = reader.ReadToEnd();
                    return text;
            }
            
            
        }

    }
    }

