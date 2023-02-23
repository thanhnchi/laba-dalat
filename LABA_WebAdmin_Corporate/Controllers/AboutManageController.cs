using LABA_WebAdmin_Corporate.ExtensionMethods;
using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using LABA_WebAdmin_Corporate.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Controllers
{
	public class AboutManageController : BaseController<AboutManageController>
	{
		private readonly IS_About _s_About;

		public AboutManageController(IS_About about)
		{
			_s_About = about;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<JsonResult> GetList(string status, int farmId = CommonConstants.OWNER_FARM_ID, string orderBy = "createdAt", bool desc = true)
		{
			var res = await _s_About.getListAboutParameter<List<M_About>>(_accessToken, status, farmId, orderBy, desc);
			return Json(new M_JResult(res));
		}

		[HttpGet]
		public IActionResult P_Add()
		{
			return PartialView();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<JsonResult> P_Add(EM_About model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.farmId = CommonConstants.OWNER_FARM_ID;
			model.createdAt = DateTime.Now;
			var res = await _s_About.Create<M_About>(_accessToken, model, _userId);
			return Json(jResult.MapData(res));
		}

		[HttpGet]
		public async Task<IActionResult> P_Edit(int id)
		{
			var res = await _s_About.getAboutUsById<M_About>(_accessToken, id);
			return Json(new M_JResult(res));
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<JsonResult> P_Edit(EM_About model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.farmId = CommonConstants.OWNER_FARM_ID;
			model.reOrder = 0;
			model.aboutType = 0;
			var res = await _s_About.Update<M_About>(_accessToken, model, _userId);
			return Json(jResult.MapData(res));
		}

		[HttpGet]
		public async Task<IActionResult> P_View(int id)
		{
			var res = await _s_About.getAboutUsById<M_About>(_accessToken, id);
			return Json(new M_JResult(res));
		}

		[HttpPost]
		public async Task<JsonResult> ChangeStatus(int id, int status, DateTime timer)
		{
			status = status == 0 ? 1 : 0;
			var res = await _s_About.UpdateStatus<M_About>(_accessToken, id, status, timer, _userId);
			return Json(new M_JResult(res));
		}

		[HttpPost]
		public async Task<JsonResult> Delete(int id)
		{
			var res = await _s_About.Delete<M_About>(_accessToken, id);
			return Json(new M_JResult(res));
		}
	}
}
