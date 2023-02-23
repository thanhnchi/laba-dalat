using LABA_WebPortal_Corporate.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Services
{
	public interface IS_News
	{
		Task<ResponseData<T>> getListNewsFilterByOrderByPagination<T>(int? typeId, string orderBy, bool desc, int page, int recordNumber);
		Task<ResponseData<T>> getListLatestNews<T>(int? typeId, string orderBy, bool desc, int recordNumber);
		Task<ResponseData<T>> getNewsByIdWithListRelated<T>(int id, int? typeId, int recordNumberRef, int recordNumberNew);
		Task<ResponseData<T>> getListNewsByCategoryId<T>(int? categoryId, string orderBy, bool desc, int page, int recordNumber);
	}
	public class S_News : IS_News
	{
		private readonly ICallBaseApi _callApi;
		public S_News(ICallBaseApi callApi)
		{
			_callApi = callApi;
		}
		public async Task<ResponseData<T>> getListNewsFilterByOrderByPagination<T>( int? typeId, string orderBy, bool desc, int page, int recordNumber)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"typeId", typeId},
				{"orderBy", orderBy},
				{"desc", desc},
				{"page", page},
				{"recordNumber", recordNumber},
			};
			return await _callApi.GetResponseDataAsync<T>("News/getListNewsFilterByOrderByPagination", dictPars);
		}	
		public async Task<ResponseData<T>> getListLatestNews<T>(int? typeId, string orderBy, bool desc, int recordNumber)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"typeId", typeId},
				{"orderBy", orderBy},
				{"desc", desc},
				{"recordNumber", recordNumber},
			};
			return await _callApi.GetResponseDataAsync<T>("News/GetListLatestNews", dictPars);
		}
		public async Task<ResponseData<T>> getNewsByIdWithListRelated<T>(int id, int? typeId, int recordNumberRef, int recordNumberNew)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
				{"typeId", typeId},
				{"recordNumberRef", recordNumberRef},
				{"recordNumberNew", recordNumberNew},
			};
			return await _callApi.GetResponseDataAsync<T>("News/getNewsByIdWithListRelated", dictPars);
		}
		public async Task<ResponseData<T>> getListNewsByCategoryId<T>(int? categoryId, string orderBy, bool desc, int page, int recordNumber)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"categoryId", categoryId},
				{"orderBy", orderBy},
				{"desc", desc},
				{"page", page},
				{"recordNumber", recordNumber},
			};
			return await _callApi.GetResponseDataAsync<T>("News/getListNewsByCategoryId", dictPars);
		}
	}
}
