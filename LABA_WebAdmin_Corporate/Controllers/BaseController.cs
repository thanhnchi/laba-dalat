using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using static System.String;

namespace LABA_WebAdmin_Corporate.Controllers
{
	[Authorize]
	public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        private IMapper mapper;
        private IHttpContextAccessor httpContextAccessor;
        private string accessToken = string.Empty;
        private string userId = string.Empty;

        protected IMapper _mapper => mapper ?? (mapper = HttpContext.RequestServices.GetService<IMapper>());

        protected IHttpContextAccessor _httpContextAccessor => httpContextAccessor ?? (httpContextAccessor = HttpContext.RequestServices.GetService<IHttpContextAccessor>());

        protected string _accessToken => IsNullOrEmpty(accessToken) ? (accessToken = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value) : accessToken;

        protected string _userId => IsNullOrEmpty(userId) ? (userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : userId;
    }
}
