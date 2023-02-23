using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Services
{
    public interface IS_Person
    {
        Task<ResponseData<T>> getHubPersonByIdStatus<T>(string access_token);
        Task<ResponseData<T>> UpdateCustomer<T>(string access_token, EM_Person model);
    }
    public class S_Person : IS_Person
    {
        private readonly ICallBaseApi _callApi;
        private readonly IS_Image _s_Image;
        public S_Person(ICallBaseApi callApi, IS_Image image)
        {
            _callApi = callApi;
            _s_Image = image;
        }

        public async Task<ResponseData<T>> getHubPersonByIdStatus<T>(string access_token)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"access_token", access_token}
            };
            return await _callApi.GetResponseDataAsync<T>("Person/getHubPersonByIdStatus", dictPars);
        }
        public async Task<ResponseData<T>> UpdateCustomer<T>(string access_token, EM_Person model)
        {
            model = CleanXSSHelper.CleanXSSObject(model); //Clean XSS
            bool isFail = false;
            ResponseData<T> res = new ResponseData<T>();
            if (model.imageFile != null)
            {
                var imgUpload = await _s_Image.Upload<M_Image>(model.imageFile, "0", CommonConstants.DIRECTORY_IMAGE_SRC, model.updatedBy?.ToString());
                if (imgUpload.result == 1 && imgUpload.data != null)
                    model.imageId = imgUpload.data.id;
                else
                {
                    isFail = true;
                    res.result = imgUpload.result; res.error = imgUpload.error;
                }
            }
            if (isFail) return res;
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"access_token", access_token},
                {"firstName", model.firstName},
                {"lastName", model.lastName},
                {"birthday", model.birthday?.ToString("yyyy-MM-dd")},
                {"gender", model.gender},
                {"email", model.email.ToLower()},
                {"imageId", model.imageId},
                {"updatedBy", model.updatedBy},
                {"status", model.status},
                {"timer", model.timer?.ToString("O")},
            };
            return await _callApi.PostResponseDataAsync<T>("Person/UpdateCustomer", dictPars);
        }
    }
}
