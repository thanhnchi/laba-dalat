using LABA_WebPortal_Corporate.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Services
{
	public interface IS_NewsCategory
	{
		Task<ResponseData<T>> getListNewsCategoryFilterBySequenceStatusFarmIdTypeIdOrderBy<T>(int? farmId, string sequenceStatus, int? typeId, string orderBy, bool desc);
		Task<ResponseData<T>> getListNewsCategoryByTypeId<T>();
		Task<ResponseData<T>> getNewsCategoryById<T>(int id);
	}
	public class S_NewsCategory : IS_NewsCategory
	{
		private readonly ICallBaseApi _callApi;
		public S_NewsCategory(ICallBaseApi callApi)
		{
			_callApi = callApi;
		}

		public async Task<ResponseData<T>> getListNewsCategoryFilterBySequenceStatusFarmIdTypeIdOrderBy<T>(int? farmId, string sequenceStatus, int? typeId, string orderBy, bool desc)
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
		public async Task<ResponseData<T>> getListNewsCategoryByTypeId<T>()
		{
			return await _callApi.GetResponseDataAsync<T>("NewsCategory/getListNewsCategoryByTypeId", default(Dictionary<string, dynamic>));
		}
		public async Task<ResponseData<T>> getNewsCategoryById<T>(int id)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
			};
			return await _callApi.GetResponseDataAsync<T>("NewsCategory/getNewsCategoryById", dictPars);
		}
	}
}
