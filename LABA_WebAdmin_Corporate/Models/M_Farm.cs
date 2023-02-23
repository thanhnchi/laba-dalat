using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static LABA_WebAdmin_Corporate.ExtensionMethods.ValidationAttribute;

namespace LABA_WebAdmin_Corporate.Models
{
	public class M_Farm : M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public string refCode { get; set; }
		public string qrIdentityCode { get; set; }
		public string farmCode { get; set; }
		public string name { get; set; }
		public string nameSlug { get; set; }
		public string slogan { get; set; }
		public string description { get; set; }
		public string businessCode { get; set; }
		public string taxCode { get; set; }
		public int? addressId { get; set; }
		public string addressList { get; set; }
		public int? telephoneId { get; set; }
		public string telephoneNumber { get; set; }
		public string email { get; set; }
		public int businessTypeId { get; set; }
		public string imageQrcode { get; set; }
		public string imageLogo { get; set; }
		public string imageFavicon { get; set; }
		public string imageList { get; set; }
		public string faceBook { get; set; }
		public string twitter { get; set; }
		public string instagram { get; set; }
		public string zalo { get; set; }
		public string siteUrl { get; set; }
		public M_Address addressObj { get; set; }

	}
	public class EM_Farm : M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public string refCode { get; set; }
		public string qrIdentityCode { get; set; }
		public string farmCode { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập tên website !")]
		public string name { get; set; }
		public string slogan { get; set; }
		public string nameSlug { get; set; }
		public string description { get; set; }
		public string businessCode { get; set; }
		public string taxCode { get; set; }
		public int? addressId { get; set; }
		public string addressList { get; set; }
		public int? telephoneId { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập số điện thoại !")]
		public string telephoneNumber { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập email !")]
		public string email { get; set; }
		public int businessTypeId { get; set; }
		public string imageLogo { get; set; }
		public string imageFavicon { get; set; }
		public string imageQrcode { get; set; }
		public string imageList { get; set; }
		public string faceBook { get; set; }
		public string twitter { get; set; }
		public string instagram { get; set; }
		public string zalo { get; set; }
		public string siteUrl { get; set; }
		[DataType(DataType.Upload)]
		[MaxFileSize(maxFileSize: Lib.CommonConstants.MAX_FILE_SIZE_IMAGE_UPLOAD * 1024 * 1024, errorMessage: "Dung lượng ảnh tối đa 5MB!")]
		[AllowedExtensions(extensions: new string[] { ".jpg", ".jpeg", ".png", ".ico", ".svg" }, errorMessage: "Hình ảnh không hợp lệ !")]
		public IFormFile imageLogoFile { get; set; }
		[DataType(DataType.Upload)]
		[MaxFileSize(maxFileSize: Lib.CommonConstants.MAX_FILE_SIZE_IMAGE_UPLOAD * 1024 * 1024, errorMessage: "Dung lượng ảnh tối đa 5MB!")]
		[AllowedExtensions(extensions: new string[] { ".jpg", ".jpeg", ".png", ".ico", ".svg" }, errorMessage: "Hình ảnh không hợp lệ !")]
		public IFormFile imageFaviconFile { get; set; }
		[DataType(DataType.Upload)]
		[MaxFileSize(maxFileSize: Lib.CommonConstants.MAX_FILE_SIZE_IMAGE_UPLOAD * 1024 * 1024, errorMessage: "Dung lượng ảnh tối đa 5MB!")]
		[AllowedExtensions(extensions: new string[] { ".jpg", ".jpeg", ".png", ".ico", ".svg" }, errorMessage: "Hình ảnh không hợp lệ !")]
		public IFormFile imageQrcodeFile { get; set; }
		public EM_Address addressObj { get; set; }
	}
}
