using LABA_WebPortal_Corporate.ExtensionMethods;
using LABA_WebPortal_Corporate.Lib;
using LABA_WebPortal_Corporate.Models;
using LABA_WebPortal_Corporate.Services;
using LABA_WebPortal_Corporate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Controllers
{
	public class ContactController : BaseController<ContactController>
	{
		private readonly IS_Contact _s_Contact;
		private readonly IConfiguration _configuration;
		private readonly IOptions<Config_MetaSEO> _metaSEO;
		public ContactController(IS_Contact contact, IConfiguration configuration, IOptions<Config_MetaSEO> metaSEO)
		{
			_s_Contact = contact;
			_configuration = configuration;
			_metaSEO = metaSEO;
		}

		public IActionResult Index()
		{
			ViewData["KeyGoogleMap"] = _configuration.GetValue<string>("KeyGoogleMap");
			ExtensionMethods.SetViewDataSEOExtensionMethod.SetViewDataSEODefaultAllStaticImagePrevice(this, _metaSEO.Value.Contact);
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<JsonResult> SubmitContact(EM_Contact model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.farmId = CommonConstants.OWNER_FARM_ID;
			var res = await _s_Contact.Create<M_Contact>(model);
			return Json(jResult.MapData(res));
		}
	}
}
