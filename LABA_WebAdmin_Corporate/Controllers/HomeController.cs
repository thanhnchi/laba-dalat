using LABA_WebAdmin_Corporate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Controllers
{
	public class HomeController : BaseController<HomeController>
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
