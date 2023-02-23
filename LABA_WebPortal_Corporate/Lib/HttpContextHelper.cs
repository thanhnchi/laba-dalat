using Microsoft.AspNetCore.Http;

namespace LABA_WebPortal_Corporate.Lib
{
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor _contextAccessor;

        public static HttpContext Current => _contextAccessor.HttpContext;

        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
