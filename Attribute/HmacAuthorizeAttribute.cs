using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
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
        public HmacAuthorizeFilter(IHmacValidation hmacValidation) 
        { 
            _hmacValidation= hmacValidation;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("X-Digest") && !context.HttpContext.Request.Headers.ContainsKey("X-UserId"))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                context.HttpContext.Request.Headers.TryGetValue("X-Digest", out var headerDigestValue);
                context.HttpContext.Request.Headers.TryGetValue("X-UserId", out var headerUserIdValue);
                var isValid = _hmacValidation.Validation(headerUserIdValue, headerDigestValue);
                

            }


        }
    }
}
