using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using static LABA_WebAdmin_Corporate.ExtensionMethods.ValidationAttribute;

namespace LABA_WebAdmin_Corporate.Models
{
	public class M_NewsCategory : M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public int parentId { get; set; }
		public int farmId { get; set; }
		public string name { get; set; }
		public string nameSlug { get; set; }
		public int typeId { get; set; }
		public int reOrder { get; set; }
		public int imageId { get; set; }
		public int? imageSerialId { get; set; }
		public string description { get; set; }
		public string metaTitle { get; set; }
		public string metaKeyword { get; set; }
		public string metaDescription { get; set; }
		public M_Farm farmObj { get; set; }
		public M_Image imageObj { get; set; }
	}
	public class EM_NewsCategory : M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public int parentId { get; set; }
		public int farmId { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập tên !")]
		public string name { get; set; }
		public string nameSlug { get; set; }
		public int typeId { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn thứ tự !")]
		public int reOrder { get; set; }
		public int? imageId { get; set; }
		public int? imageSerialId { get; set; }
		public string description { get; set; }
		public string metaTitle { get; set; }
		public string metaKeyword { get; set; }
		public string metaDescription { get; set; }
		public M_Farm farmObj { get; set; }
		public M_Image imageObj { get; set; }
		[DataType(DataType.Upload)]
		[MaxFileSize(maxFileSize: Lib.CommonConstants.MAX_FILE_SIZE_IMAGE_UPLOAD * 1024 * 1024, errorMessage: "Dung lượng ảnh tối đa 10MB!")]
		[AllowedExtensions(extensions: new string[] { ".jpg", ".jpeg", ".png", ".ico", ".svg" }, errorMessage: "Hình ảnh không hợp lệ !")]
		public IFormFile imageFile { get; set; }
	}
}
