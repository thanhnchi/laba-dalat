using LABA_WebPortal_Corporate.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Services
{
	public interface IS_Home
	{
		Task<ResponseData<T>> getNewsCategoryAboutNewsFarmById<T>(int farmId, int isHot, int recordNews, int typeId);
	}
	public class S_Home : IS_Home
	{
		private readonly ICallBaseApi _callApi;
		public S_Home(ICallBaseApi callApi)
		{
			_callApi = callApi;
		}
		public async Task<ResponseData<T>> getNewsCategoryAboutNewsFarmById<T>(int farmId, int isHot, int recordNews, int typeId)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"farmId", farmId},
				{"isHot", isHot},
				{"recordNews", recordNews},
				{"typeId", typeId},
			};
			return await _callApi.GetResponseDataAsync<T>("Home/getNewsCategoryAboutNewsFarmById", dictPars);
		}
	}
}
