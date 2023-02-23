using LABA_WebAdmin_Corporate.Services;
using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LABA_WebAdmin_Corporate.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using LABA_WebAdmin_Corporate.ExtensionMethods;

namespace LABA_WebAdmin_Corporate.Controllers
{
	public class FarmManageController : BaseController<FarmManageController>
	{
		private readonly IS_Farm _s_Farm;
		private readonly IS_Address _s_Address;
		private readonly IConfiguration _configuration;

		public FarmManageController(IS_Farm farm, IS_Address address, IConfiguration configuration)
		{
			_s_Farm = farm;
			_s_Address = address;
			_configuration = configuration;
		}
		private async Task SetDropDownProvince(string selectedId = "0")
		{
			List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
			var res = await _s_Address.getListProvinceByCountryId<List<M_Province>>();
			if (res.result == 1 && res.data != null)
				result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
			ViewBag.ProvinceId = new SelectList(result, "Id", "Name", selectedId);
		}
		private async Task SetDropDownDistrict(string provinceId, string selectedId = "0")
		{
			List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
			var res = await _s_Address.getListDistrictByProvinceId<List<M_District>>(provinceId);
			if (res.result == 1 && res.data != null)
				result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
			ViewBag.DistrictId = new SelectList(result, "Id", "Name", selectedId);
		}
		private async Task SetDropDownWard(string districtId, string selectedId = "0")
		{
			List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
			var res = await _s_Address.getListWardByDisctrictId<List<M_Ward>>(districtId);
			if (res.result == 1 && res.data != null)
				result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
			ViewBag.WardId = new SelectList(result, "Id", "Name", selectedId);
		}
		public async Task<IActionResult> Index()
		{
			var res = await _s_Farm.getFarmById<M_Farm>(_accessToken, CommonConstants.OWNER_FARM_ID);
			if (res.result == 1 && res.data != null)
			{
				Task provinceTask = SetDropDownProvince(res.data.addressObj?.countryId?.ToString()),
				 districtTask = SetDropDownDistrict(res.data.addressObj?.provinceId?.ToString(), res.data.addressObj?.districtId?.ToString()),
				 wardTask = SetDropDownWard(res.data.addressObj?.districtId?.ToString(), res.data.addressObj?.wardId?.ToString());

				await Task.WhenAll(provinceTask, districtTask, wardTask);

				ViewData["KeyGoogleMap"] = _configuration.GetValue<string>("KeyGoogleMap");
				return View(_mapper.Map<EM_Farm>(res.data));
			}
			return Redirect($"/error/{res.error.code}");
		}
		
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> P_Edit(EM_Farm model)
		{
			M_JResult jResult = new M_JResult();
			if (!ModelState.IsValid)
			{
				jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
				return Json(jResult);
			}
			model.id = CommonConstants.OWNER_FARM_ID;
			var res = await _s_Farm.Update<M_Farm>(_accessToken, model, _userId);
			if (res.result != 1 || res.data == null) return Json(jResult.MapData(res));
			EM_Farm farm = _mapper.Map<EM_Farm>(res.data);
			return Json(jResult.MapData(res, farm));
		}
	}
}
