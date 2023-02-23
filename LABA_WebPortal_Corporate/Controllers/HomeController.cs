using LABA_WebPortal_Corporate.Lib;
using LABA_WebPortal_Corporate.Models;
using LABA_WebPortal_Corporate.Services;
using LABA_WebPortal_Corporate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using static System.String;

namespace LABA_WebPortal_Corporate.Controllers
{
	public class HomeController : BaseController<HomeController>
	{
		private readonly IS_Home _s_Home;
		private readonly IOptions<Config_MetaSEO> _metaSEO;

		public HomeController(IS_Home home, IOptions<Config_MetaSEO> metaSEO)
		{
			_s_Home = home;
			_metaSEO = metaSEO;
		}

		public async Task<IActionResult> Index()
		{

			var res = await _s_Home.getNewsCategoryAboutNewsFarmById<M_Home>(CommonConstants.OWNER_FARM_ID, 1, 4, 2);

			ExtensionMethods.SetViewDataSEOExtensionMethod.SetViewDataSEODefaultAll(this, _metaSEO.Value.Home);

			return View(res.data ?? new M_Home());
		}
	}
}
