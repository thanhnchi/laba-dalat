using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LABA_WebAdmin_Corporate.Lib.SecurityManager;
using static System.String;

namespace LABA_WebAdmin_Corporate.Controllers
{
	public class AccountController : BaseController<AccountController>
	{
		private SecurityManager _securityManager = new SecurityManager();

		#region Sign in & Sign out
		[HttpGet, AllowAnonymous]
		public IActionResult SignIn(string returnUrl)
		{
			if (User.Identity.IsAuthenticated)
				return IsNullOrEmpty(returnUrl) ? Redirect("/") : Redirect(returnUrl);
			return View();
		}

		[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
		public async Task<JsonResult> SignIn(EM_AccountSignIn model, string returnUrl)
		{
			M_JResult jResult = new M_JResult();
			//Check is stayLogin, if true set time 30 days
			int timeOut = model.stayLoggedIn ? 60 * 24 * 30 : 30; //Minute
			List<M_Account> accountData = new List<M_Account>
			{
				new M_Account
				{
					id = 1,
					userName = "labanamle",
					fullName = "Nam Lê",
					password = "laba@namle",
					avatar = "/assets/images/users/user-1.jpg",
				},
				new M_Account
				{
					id = 2,
					userName = "labaadmin",
					fullName = "Quản trị viên",
					password = "laba@admin",
					avatar = "/assets/images/users/user-2.jpg",
				},
				new M_Account
				{
					id = 3,
					userName = "labamanager",
					fullName = "Biên tập viên",
					password = "laba@manager",
					avatar = "/assets/images/users/user-3.jpg",
				},
				new M_Account
				{
					id = 3,
					userName = "0326280179",
					fullName = "Thành Nguyễn",
					password = "@dmin123",
					avatar = "/assets/images/users/user-4.png",
				},
				new M_Account
				{
					id = 3,
					userName = "xuanthu",
					fullName = "Xuân Thu",
					password = "Xuanthu@@123#",
					avatar = "/assets/images/kadon_ekopark/kadon_ekopark.png",
				},
			};
			ResponseData<M_Account> res = new ResponseData<M_Account>();
			var find = accountData.FirstOrDefault(x => x.userName.Equals(model.userName) && x.password.Equals(model.password));

			if (find == null)
			{
				res.error.message = "Tài khoản hoặc mật khẩu không chính xác";
				return Json(jResult.MapData(res, returnUrl));
			}

			M_AccountSecurity account = new M_AccountSecurity()
			{
				accountId = find.id.ToString(),
				name = find.fullName,
				userName = model.userName,
				password = model.password,
				avatar = find.avatar,
				timeOut = timeOut,
			};
			_securityManager.SignIn(this.HttpContext, account, CookieAuthenticationDefaults.AuthenticationScheme);
			res.result = 1;
			return Json(jResult.MapData(res, returnUrl));
		}

		public IActionResult SignOut(string returnUrl, int? autoLogout)
		{
			if (User.Identity.IsAuthenticated)
				_securityManager.SignOut(this.HttpContext, CookieAuthenticationDefaults.AuthenticationScheme);
			//Auto logout when other user signin
			if (autoLogout != null)
			{
				switch (autoLogout)
				{
					case 1: TempData["AutoLogoutMessage"] = "Tài khoản của bạn vừa được đăng xuất một nơi khác!"; break;
					case 2: TempData["AutoLogoutMessage"] = "Tài khoản của bạn vừa được truy cập ở một nơi khác!"; break;
					default: break;
				}
			}
			if (!IsNullOrEmpty(returnUrl))
				return Redirect($"/account/signin?returnUrl={returnUrl}");
			return Redirect("/account/signin");
		}

		#endregion

	}
}
