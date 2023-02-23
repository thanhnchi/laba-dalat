using LABA_WebPortal_Corporate.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Services
{
	public interface IS_About
	{
		Task<ResponseData<T>> getAboutUsByIdIsHotWithListRelated<T>(int? id, string sequenceStatus, int? isHot, string orderBy, bool desc);
		Task<ResponseData<T>> getAboutUsByIdWithListRelated<T>(int? id, string orderBy, bool desc);
	}
	public class S_About : IS_About
	{
		private readonly ICallBaseApi _callApi;
		public S_About(ICallBaseApi callApi)
		{
			_callApi = callApi;
		}
		public async Task<ResponseData<T>> getAboutUsByIdIsHotWithListRelated<T>(int? id, string sequenceStatus, int? isHot, string orderBy, bool desc)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
				{"sequenceStatus", sequenceStatus},
				{"isHot", isHot},
				{"orderBy", orderBy},
				{"desc", desc},
			};
			return await _callApi.GetResponseDataAsync<T>("AboutUs/getAboutUsByIdIsHotWithListRelated", dictPars);
		}		
		public async Task<ResponseData<T>> getAboutUsByIdWithListRelated<T>(int? id,  string orderBy, bool desc)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
				{"orderBy", orderBy},
				{"desc", desc},
			};
			return await _callApi.GetResponseDataAsync<T>("AboutUs/getAboutUsByIdWithListRelated", dictPars);
		}
	}
}
