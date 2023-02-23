using LABA_WebPortal_Corporate.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Services
{
	public interface IS_Farm
	{
		Task<ResponseData<T>> getFarmById<T>(int id);
	}
	public class S_Farm : IS_Farm
	{
		private readonly ICallBaseApi _callApi;
		public S_Farm(ICallBaseApi callApi)
		{
			_callApi = callApi;
		}

		public async Task<ResponseData<T>> getFarmById<T>(int id)
		{
			Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
			{
				{"id", id},
			};
			return await _callApi.GetResponseDataAsync<T>("Farm/getFarmById", dictPars);
		}
	}
}
