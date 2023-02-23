using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static LABA_WebAdmin_Corporate.ExtensionMethods.ValidationAttribute;

namespace LABA_WebAdmin_Corporate.Models
{
	public class M_About : M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public int farmId { get; set; }
		public string title { get; set; }
		public string titleSlug { get; set; }
		public string description { get; set; }
		public string detail { get; set; }
		public int? imageId { get; set; }
		public int? imageSerialId { get; set; }
		public string imageList { get; set; }
		public string linkRef { get; set; }
		public long? likeNumber { get; set; }
		public long? viewNumber { get; set; }
		public int isHot { get; set; }
		public int? reOrder { get; set; }
		public int? aboutType { get; set; }
		public DateTime? publishedAt { get; set; }
		public string metaTitle { get; set; }
		public string metaKeyword { get; set; }
		public string metaDescription { get; set; }
		public string metaImageReview { get; set; }
		public M_Farm farmObj { get; set; }
		public M_Image imageObj { get; set; }
	}
	public class EM_About : M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public int farmId { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập tiêu đề !")]
		public string title { get; set; }
		public string titleSlug { get; set; }
		public string description { get; set; }
		public string detail { get; set; }
		public int? imageId { get; set; }
		public int? imageSerialId { get; set; }
		public string imageList { get; set; }
		public string linkRef { get; set; }
		public long? likeNumber { get; set; }
		public long? viewNumber { get; set; }
		public bool isHot { get; set; }
		public int? reOrder { get; set; }
		public int? aboutType { get; set; }
		public DateTime? publishedAt { get; set; }
		public string metaTitle { get; set; }
		public string metaKeyword { get; set; }
		public string metaDescription { get; set; }
		public string metaImageReview { get; set; }
		public M_Farm farmObj { get; set; }
		public M_Image imageObj { get; set; }
		[DataType(DataType.Upload)]
		[MaxFileSize(maxFileSize: Lib.CommonConstants.MAX_FILE_SIZE_IMAGE_UPLOAD * 1024 * 1024, errorMessage: "Dung lượng ảnh tối đa 10MB!")]
		[AllowedExtensions(extensions: new string[] { ".jpg", ".jpeg", ".png", ".ico", ".svg" }, errorMessage: "Hình ảnh không hợp lệ !")]
		public IFormFile imageFile { get; set; }
	}
}
