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
	public class ServicesManageController : BaseController<ServicesManageController>
	{
		private readonly IS_News _s_News;

		public ServicesManageController(IS_News news)
		{
			_s_News = news;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<JsonResult> GetList(int? categoryId, string status)
		{
			int farmId = CommonConstants.OWNER_FARM_ID, typeId = CommonConstants.OWNER_SERVICES_TYPE_ID;
			string orderBy = "createdAt";
			bool desc = true;
			var res = await _s_News.getListNewsParameter<List<M_News>>(_accessToken, typeId, categoryId, status, farmId, orderBy, desc);
			return Json(new M_JResult(res));
		}

		[HttpGet]
		public IActionResult P_Add()
		{
			return PartialView();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<JsonResult> P_Add(EM_News model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.farmId = CommonConstants.OWNER_FARM_ID;
			var res = await _s_News.Create<M_News>(_accessToken, model, _userId);
			return Json(jResult.MapData(res));
		}

		[HttpGet]
		public async Task<IActionResult> P_Edit(int id)
		{
			var res = await _s_News.getNewsById<M_News>(_accessToken, id);
			return Json(new M_JResult(res));
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<JsonResult> P_Edit(EM_News model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.farmId = CommonConstants.OWNER_FARM_ID;
			var res = await _s_News.Update<M_News>(_accessToken, model, _userId);
			return Json(jResult.MapData(res));
		}

		[HttpGet]
		public async Task<IActionResult> P_View(int id)
		{
			var res = await _s_News.getNewsById<M_News>(_accessToken, id);
			return Json(new M_JResult(res));
		}

		[HttpPost]
		public async Task<JsonResult> ChangeStatus(int id, int status, DateTime timer)
		{
			var res = await _s_News.UpdateStatus<M_News>(_accessToken, id, status, timer, _userId);
			return Json(new M_JResult(res));
		}

		[HttpPost]
		public async Task<JsonResult> Delete(int id)
		{
			var res = await _s_News.Delete<M_News>(_accessToken, id);
			return Json(new M_JResult(res));
		}
	}
}
