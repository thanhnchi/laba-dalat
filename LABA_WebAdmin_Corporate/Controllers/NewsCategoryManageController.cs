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
	public class NewsCategoryManageController : BaseController<NewsCategoryManageController>
	{
		private readonly IS_NewsCategory _s_NewsCategory;

		public NewsCategoryManageController(IS_NewsCategory newsCategory)
		{
			_s_NewsCategory = newsCategory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<JsonResult> GetList(string status)
		{
			var res = await _s_NewsCategory.getListNewsCategoryParameter<List<M_NewsCategory>>(_accessToken, CommonConstants.OWNER_FARM_ID, status, CommonConstants.OWNER_NEWS_TYPE_ID, "createdAt", true);
			return Json(new M_JResult(res));
		}
		[HttpGet]
		public IActionResult P_Add()
		{
			return PartialView();
		}
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<JsonResult> P_Add(EM_NewsCategory model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.farmId = CommonConstants.OWNER_FARM_ID;
			model.typeId = CommonConstants.OWNER_NEWS_TYPE_ID;
			var res = await _s_NewsCategory.Create<M_NewsCategory>(_accessToken, model, _userId);
			return Json(jResult.MapData(res));
		}
		public async Task<JsonResult> P_Edit(int id)
		{
			var res = await _s_NewsCategory.getNewsCategoryById<M_NewsCategory>(_accessToken, id);
			return res.result == 1 && res.data != null ? Json(new M_JResult(res, _mapper.Map<EM_NewsCategory>(res.data))) : Json(new M_JResult(res));
		}
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<JsonResult> P_Edit(EM_NewsCategory model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.farmId = CommonConstants.OWNER_FARM_ID;
			model.typeId = model.typeId == 2 ? model.typeId : CommonConstants.OWNER_NEWS_TYPE_ID;
			var res = await _s_NewsCategory.Update<M_NewsCategory>(_accessToken, model, _userId);
			return Json(jResult.MapData(res));
		}
		[HttpGet]
		public async Task<IActionResult> P_View(int id)
		{
			var res = await _s_NewsCategory.getNewsCategoryById<M_NewsCategory>(_accessToken, id);
			return Json(new M_JResult(res));
		}
		[HttpPost]
		public async Task<JsonResult> ChangeStatus(int id, int status, DateTime timer)
		{
			var res = await _s_NewsCategory.UpdateStatus<M_NewsCategory>(_accessToken, id, status, timer, _userId);
			return Json(new M_JResult(res));
		}
		[HttpPost]
		public async Task<JsonResult> Delete(int id)
		{
			var res = await _s_NewsCategory.Delete<M_NewsCategory>(_accessToken, id);
			return Json(new M_JResult(res));
		}
	}
}
