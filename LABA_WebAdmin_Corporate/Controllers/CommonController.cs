using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using LABA_WebAdmin_Corporate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Controllers
{
	public class CommonController : BaseController<CommonController>
	{
		private readonly IS_Address _s_Address;
		private readonly IS_NewsCategory _s_NewsCategory;
		private readonly IS_Image _s_Image;

		public CommonController(IS_Address address, IS_NewsCategory newsCategory, IS_Image image)
		{
			_s_Address = address;
			_s_NewsCategory = newsCategory;
			_s_Image = image;
		}

		[HttpGet]
		public async Task<JsonResult> GetListDropdownProvince()
		{
			var res = await _s_Address.getListProvinceByCountryId<List<M_Province>>();
			return Json(new M_JResult(res));
		}

		[HttpGet]
		public async Task<JsonResult> GetListDropdownDistrict(string provinceId)
		{
			var res = await _s_Address.getListDistrictByProvinceId<List<M_Province>>(provinceId);
			return Json(new M_JResult(res));
		}

		[HttpGet]
		public async Task<JsonResult> GetListDropdownWard(string districtId)
		{
			var res = await _s_Address.getListWardByDisctrictId<List<M_Province>>(districtId);
			return Json(new M_JResult(res));
		}

		[HttpGet]
		public async Task<JsonResult> GetListDropdownServicesCategory()
		{
			int farmId = CommonConstants.OWNER_FARM_ID;
			string sequenceStatus = "1", orderBy = "createdAt";
			int typeId = CommonConstants.OWNER_SERVICES_TYPE_ID;
			bool desc = true;
			var res = await _s_NewsCategory.getListNewsCategoryParameter<List<M_NewsCategory>>(_accessToken, farmId, sequenceStatus, typeId, orderBy, desc);
			return Json(new M_JResult(res));
		}

		[HttpGet]
		public async Task<JsonResult> GetListDropdownNewsCategory()
		{
			int farmId = CommonConstants.OWNER_FARM_ID;
			string sequenceStatus = "1",orderBy = "createdAt";
			int typeId = CommonConstants.OWNER_NEWS_TYPE_ID; 
			bool desc = true;
			var res = await _s_NewsCategory.getListNewsCategoryParameter<List<M_NewsCategory>>(_accessToken, farmId,  sequenceStatus,  typeId,  orderBy,  desc);
			return Json(new M_JResult(res));
		}
		public async Task<JsonResult> ImageUpload(IFormFile imgFile)
		{
			M_JResult jResult = new M_JResult();
			if (imgFile == null)
			{
				jResult.error = new error(0, "Không nhận được ảnh truyền vào!");
				return Json(jResult);
			}
			var res = await _s_Image.Upload<M_Image>(imgFile, CommonConstants.IMAGE_REFID, string.Empty, _userId);
			return Json(new M_JResult(res));
		}
	}
}
