using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Services
{
	public interface IS_About
	{
		Task<ResponseData<T>> getListAboutParameter<T>(string accessToken, string sequenceStatus, int farmId, string orderBy, bool desc);
		Task<ResponseData<T>> getAboutUsById<T>(string accessToken, int id);
		Task<ResponseData<T>> Create<T>(string accessToken, EM_About model, string createdBy);
		Task<ResponseData<T>> Update<T>(string accessToken, EM_About model, string updatedBy);
		Task<ResponseData<T>> UpdateStatus<T>(string accessToken, int id, int status, DateTime timer, string updatedBy);
		Task<ResponseData<T>> Delete<T>(string accessToken, int id);
	}
	public class S_About : IS_About
	{
		private readonly ICallBaseApi _callApi;
		private readonly IS_Image _s_Image;

		public S_About(ICallBaseApi callApi, IS_Image image)
		{
			_callApi = callApi;
			_s_Image = image;
		}

		public async Task<ResponseData<T>> getListAboutParameter<T>(string accessToken, string sequenceStatus, int farmId, string orderBy, bool desc)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"farmId", farmId},
				{"sequenceStatus", sequenceStatus},
				{"orderBy", orderBy},
				{"desc", desc},
			};
			return await _callApi.GetResponseDataAsync<T>("AboutUs/getListAboutUsFilterBySequenceStatusFarmIdOrderBy", dictPars);
		}
		public async Task<ResponseData<T>> getAboutUsById<T>(string accessToken, int id)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
			};
			return await _callApi.GetResponseDataAsync<T>("AboutUs/getAboutUsById", dictPars);
		}
		public async Task<ResponseData<T>> Create<T>(string accessToken, EM_About model, string createdBy)
		{
			model = CleanXSSHelper.CleanXSSObject(model); //Clean XSS
			ResponseData<T> res = new ResponseData<T>();
			if (model.imageFile != null)
			{
				var imgUpload = await _s_Image.Upload<M_Image>(model.imageFile, CommonConstants.IMAGE_REFID, string.Empty, createdBy);
				if (imgUpload.result == 1 && imgUpload.data != null)
				{
					model.imageId = imgUpload.data.id;
					model.imageSerialId = imgUpload.data.serialId;
				}
				else
				{
					res.result = imgUpload.result; res.error = imgUpload.error;
					return res;
				}
			}
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"farmId", model.farmId},
				{"title", model.title},
				{"description", model.description},
				{"detail", model.detail},
				{"imageId", model.imageId},
				{"imageSerialId", model.imageSerialId},
				{"isHot", model.isHot ? 1 : 0},
				{"createdBy", createdBy},
			};
			return await _callApi.PostResponseDataAsync<T>("AboutUs/Create", dictPars);
		}
		public async Task<ResponseData<T>> Update<T>(string accessToken, EM_About model, string updatedBy)
		{
			model = CleanXSSHelper.CleanXSSObject(model); //Clean XSS
			ResponseData<T> res = new ResponseData<T>();
			if (model.imageFile != null)
			{
				var imgUpload = await _s_Image.Upload<M_Image>(model.imageFile, CommonConstants.IMAGE_REFID, string.Empty, updatedBy);
				if (imgUpload.result == 1 && imgUpload.data != null)
				{
					model.imageId = imgUpload.data.id;
					model.imageSerialId = imgUpload.data.serialId;
				}
				else
				{
					res.result = imgUpload.result; res.error = imgUpload.error;
					return res;
				}
			}
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", model.id},
				{"farmId", model.farmId},
				{"title", model.title},
				{"description", model.description},
				{"detail", model.detail},
				{"imageId", model.imageId},
				{"imageSerialId", model.imageSerialId},
				{"imageList", model.imageList},
				{"linkRef", model.linkRef},
				{"isHot",  model.isHot ? 1 : 0},
				{"reOrder", model.reOrder},
				{"aboutType", model.aboutType},
				{"publishedAt", model.publishedAt?.ToString("O")},
				{"metaTitle", model.metaTitle},
				{"metaKeyword", model.metaKeyword},
				{"metaDescription", model.metaDescription},
				{"metaImageReview", model.metaImageReview},
				{"status", model.status},
				{"updatedBy", updatedBy},
				{"timer", model.timer?.ToString("O")},
			};
			return await _callApi.PutResponseDataAsync<T>("AboutUs/Update", dictPars);
		}
		public async Task<ResponseData<T>> UpdateStatus<T>(string accessToken, int id, int status, DateTime timer, string updatedBy)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
				{"status", status},
				{"updatedBy", updatedBy},
				{"timer", timer.ToString("O")},
			};
			return await _callApi.PutResponseDataAsync<T>("AboutUs/UpdateStatus", dictPars);
		}
		public async Task<ResponseData<T>> Delete<T>(string accessToken, int id)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
			};
			return await _callApi.DeleteResponseDataAsync<T>("AboutUs/Delete", dictPars);
		}
	}
}
