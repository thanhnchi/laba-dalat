using LABA_WebPortal_Corporate.Lib;
using LABA_WebPortal_Corporate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Services
{
	public interface IS_Contact
	{
		Task<ResponseData<T>> Create<T>(EM_Contact model);
	}
	public class S_Contact : IS_Contact
	{
		private readonly ICallBaseApi _callApi;
		public S_Contact(ICallBaseApi callApi)
		{
			_callApi = callApi;
		}

        public async Task<ResponseData<T>> Create<T>(EM_Contact model)
        {
            model = CleanXSSHelper.CleanXSSObject(model); //Clean XSS
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"farmId", model.farmId},
                {"name", model.name},
                {"email", model.email},
                {"phoneNumber", model.phoneNumber},
                {"title", model.title},
                {"detail", model.detail},
                {"remark", model.remark},
            };
            return await _callApi.PostResponseDataAsync<T>("Contact/Create", dictPars);
        }
    }
}
