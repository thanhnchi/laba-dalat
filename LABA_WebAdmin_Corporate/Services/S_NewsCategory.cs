using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Services
{
	public interface IS_NewsCategory
	{
		Task<ResponseData<T>> getListNewsCategoryParameter<T>(string accessToken, int farmId, string sequenceStatus, int typeId, string orderBy, bool desc);
		Task<ResponseData<T>> getNewsCategoryById<T>(string accessToken, int id);
		Task<ResponseData<T>> Create<T>(string accessToken, EM_NewsCategory model, string createdBy);
		Task<ResponseData<T>> Update<T>(string accessToken, EM_NewsCategory model, string updatedBy);
		Task<ResponseData<T>> UpdateStatus<T>(string accessToken, int id, int status, DateTime timer, string updatedBy);
		Task<ResponseData<T>> Delete<T>(string accessToken, int id);
	}
	public class S_NewsCategory : IS_NewsCategory
	{
		private readonly ICallBaseApi _callApi;
		private readonly IS_Image _s_Image;

		public S_NewsCategory(ICallBaseApi callApi, IS_Image image)
		{
			_callApi = callApi;
			_s_Image = image;
		}
		public async Task<ResponseData<T>> getListNewsCategoryParameter<T>(string accessToken, int farmId, string sequenceStatus, int typeId, string orderBy, bool desc)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"farmId", farmId},
				{"sequenceStatus", sequenceStatus},
				{"typeId", typeId},
				{"orderBy", orderBy},
				{"desc", desc},
			};
			return await _callApi.GetResponseDataAsync<T>("NewsCategory/getListNewsCategoryFilterBySequenceStatusFarmIdTypeIdOrderBy", dictPars);
		}
		public async Task<ResponseData<T>> getNewsCategoryById<T>(string accessToken, int id)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
			};
			return await _callApi.GetResponseDataAsync<T>("NewsCategory/getNewsCategoryById", dictPars);
		}
		public async Task<ResponseData<T>> Create<T>(string accessToken, EM_NewsCategory model, string createdBy)
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
				{"name", model.name},
				{"typeId", model.typeId},
				{"description", model.description},
				{"imageId", model.imageId},
				{"imageSerialId", model.imageSerialId},
				{"reOrder", model.reOrder},
				{"createdBy", createdBy},
			};
			return await _callApi.PostResponseDataAsync<T>("NewsCategory/Create", dictPars);
		}
		public async Task<ResponseData<T>> Update<T>(string accessToken, EM_NewsCategory model, string updatedBy)
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
				{"name", model.name},
				{"typeId", model.typeId},
				{"description", model.description},
				{"imageId", model.imageId},
				{"imageSerialId", model.imageSerialId},
				{"reOrder", model.reOrder},
				{"status", model.status},
				{"updatedBy", updatedBy},
				{"timer", model.timer?.ToString("O")},
			};
			return await _callApi.PutResponseDataAsync<T>("NewsCategory/Update", dictPars);
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
			return await _callApi.PutResponseDataAsync<T>("NewsCategory/UpdateStatus", dictPars);
		}
		public async Task<ResponseData<T>> Delete<T>(string accessToken, int id)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
			};
			return await _callApi.DeleteResponseDataAsync<T>("NewsCategory/Delete", dictPars);
		}
	}
}
