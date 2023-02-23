using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using LABA_WebAdmin_Corporate.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Services
{
	public interface IS_Farm
	{
		Task<ResponseData<T>> getFarmById<T>(string accessToken, int id);
		Task<ResponseData<T>> Update<T>(string accessToken, EM_Farm model, string updatedBy);
	}
	public class S_Farm : IS_Farm
	{
		private readonly ICallBaseApi _callApi;
		private readonly IS_Image _s_Image;
		private readonly IS_Address _s_Address;
		public S_Farm(ICallBaseApi callApi, IS_Image image, IS_Address address)
		{
			_callApi = callApi;
			_s_Image = image;
			_s_Address = address;
		}

		public async Task<ResponseData<T>> getFarmById<T>(string accessToken, int id)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
			};
			return await _callApi.GetResponseDataAsync<T>("Farm/getFarmById", dictPars);
		}
		public async Task<ResponseData<T>> Update<T>(string accessToken, EM_Farm model, string updatedBy)
		{
			model = CleanXSSHelper.CleanXSSObject(model); //Clean XSS
			ResponseData<T> res = new ResponseData<T>();
			if (model.imageLogoFile != null)
			{
				var imgUpload = await _s_Image.Upload<M_Image>(model.imageLogoFile, CommonConstants.IMAGE_REFID, string.Empty, updatedBy);
				if (imgUpload.result == 1 && imgUpload.data != null)
					model.imageLogo = imgUpload.data.relativeUrl;
				else
				{
					res.result = imgUpload.result; res.error = imgUpload.error;
					return res;
				}
			}
			if (model.imageFaviconFile != null)
			{
				var imgUpload = await _s_Image.Upload<M_Image>(model.imageFaviconFile, CommonConstants.IMAGE_REFID, string.Empty, updatedBy);
				if (imgUpload.result == 1 && imgUpload.data != null)
					model.imageFavicon = imgUpload.data.relativeUrl;
				else
				{
					res.result = imgUpload.result; res.error = imgUpload.error;
					return res;
				}
			}
			if (model.imageQrcodeFile != null)
			{
				var imgUpload = await _s_Image.Upload<M_Image>(model.imageQrcodeFile, CommonConstants.IMAGE_REFID, string.Empty, updatedBy);
				if (imgUpload.result == 1 && imgUpload.data != null)
					model.imageQrcode = imgUpload.data.relativeUrl;
				else
				{
					res.result = imgUpload.result; res.error = imgUpload.error;
					return res;
				}
			}
			if (model.addressId != null && model.addressId != 0)
			{
				model.addressObj.id = model.addressId;
				var resAddress = await _s_Address.Update<M_Address>(accessToken, model.addressObj, updatedBy);
				if (resAddress.result != 1 || resAddress.data == null)
				{
					res.result = resAddress.result; res.error = resAddress.error;
					return res;
				}
			}
			else
			{
				var resAddress = await _s_Address.Create<M_Address>(accessToken, model.addressObj, updatedBy);
				if (resAddress.result == 1 && resAddress.data != null)
					model.addressId = resAddress.data.id;
				else
				{
					res.result = resAddress.result; res.error = resAddress.error;
					return res;
				}
			}
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", model.id},
				{"refCode", model.refCode},
				{"qrIdentityCode", model.qrIdentityCode},
				{"farmCode", model.farmCode},
				{"name", model.name},
				{"slogan", model.slogan},
				{"description", model.description},
				{"businessCode", model.businessCode},
				{"taxCode", model.taxCode},
				{"addressId", model.addressId},
				{"addressList", model.addressList},
				{"telephoneId", model.telephoneId ?? 0},
				{"telephoneNumber", model.telephoneNumber},
				{"email", model.email.ToLower()},
				{"businessTypeId", model.businessTypeId},
				{"imageQrcode", model.imageQrcode},
				{"imageLogo", model.imageLogo},
				{"imageFavicon", model.imageFavicon},
				{"imageList", model.imageList},
				{"faceBook", model.faceBook},
				{"twitter", model.twitter},
				{"instagram", model.instagram},
				{"zalo", model.zalo},
				{"siteUrl", model.siteUrl},
				{"status", 1},
				{"updatedBy", updatedBy},
				{"timer", model.timer?.ToString("O")},
			};
			return await _callApi.PutResponseDataAsync<T>("Farm/Update", dictPars);
		}
	}
}
