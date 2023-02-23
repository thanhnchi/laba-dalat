using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Services
{
	public interface IS_Address
	{
		Task<ResponseData<T>> getListCountry<T>();
		Task<ResponseData<T>> getListProvinceByCountryId<T>(string countryId = "1");
		Task<ResponseData<T>> getListDistrictByProvinceId<T>(string countryId = "0");
		Task<ResponseData<T>> getListWardByDisctrictId<T>(string countryId = "0");
		Task<ResponseData<T>> Create<T>(string accessToken, EM_Address model, string createdBy);
		Task<ResponseData<T>> Update<T>(string accessToken, EM_Address model, string updatedBy);
	}
	public class S_Address : IS_Address
	{
		private readonly ICallBaseApi _callApi;
		public S_Address(ICallBaseApi callApi)
		{
			_callApi = callApi;
		}

		public async Task<ResponseData<T>> getListCountry<T>()
		{
			return await _callApi.GetResponseDataAsync<T>("Country/getListCountry", default(Dictionary<string, dynamic>));
		}
		public async Task<ResponseData<T>> getListProvinceByCountryId<T>(string countryId = "1")
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"countryId", countryId},
			};
			return await _callApi.GetResponseDataAsync<T>("Province/getListProvinceByCountryId", dictPars);
		}
		public async Task<ResponseData<T>> getListDistrictByProvinceId<T>(string provinceId = "0")
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"provinceId", provinceId},
			};
			return await _callApi.GetResponseDataAsync<T>("District/getListDistrictByProvinceId", dictPars);
		}
		public async Task<ResponseData<T>> getListWardByDisctrictId<T>(string districtId = "0")
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"districtId", districtId},
			};
			return await _callApi.GetResponseDataAsync<T>("Ward/getListWardByDistrictId", dictPars);
		}
		public async Task<ResponseData<T>> Create<T>(string accessToken, EM_Address model, string createdBy)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"addressNumber", model.addressNumber},
				{"addressText", model.addressText},
				{"countryId", model.countryId ?? 1},
				{"provinceId", model.provinceId},
				{"districtId", model.districtId},
				{"wardId", model.wardId},
				{"latitude", model.latitude},
				{"longitude", model.longitude},
				{"createdBy", createdBy},
			};
			return await _callApi.PostResponseDataAsync<T>("Address/Create", dictPars);
		}
		public async Task<ResponseData<T>> Update<T>(string accessToken, EM_Address model, string updatedBy)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", model.id},
				{"addressNumber", model.addressNumber},
				{"addressText", model.addressText},
				{"countryId", model.countryId ?? 1},
				{"provinceId", model.provinceId},
				{"districtId", model.districtId},
				{"wardId", model.wardId},
				{"latitude", model.latitude},
				{"longitude", model.longitude},
				{"status", model.status},
				{"updatedBy", updatedBy},
				{"timer", model.timer?.ToString("O")},
			};
			return await _callApi.PutResponseDataAsync<T>("Address/Update", dictPars);
		}
	}
}
