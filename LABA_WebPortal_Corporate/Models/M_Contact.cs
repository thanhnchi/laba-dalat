using System.ComponentModel.DataAnnotations;

namespace LABA_WebPortal_Corporate.Models
{
	public class M_Contact:M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public int? farmId { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string phoneNumber { get; set; }
		public string title { get; set; }
		public string detail { get; set; }
		public string remark { get; set; }
		public int typeId { get; set; }
	}
	public class EM_Contact : M_BaseModel.BaseCustom
	{
		public int id { get; set; }
		public int? farmId { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập tên")]
		[StringLength(50, ErrorMessage = "Tên có độ dài tối đa 50 ký tự")]
		public string name { get; set; }

		[StringLength(100, ErrorMessage = "Email có độ dài tối đa 100 ký tự")]
		[RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Email không hợp lệ")]
		public string email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
		[StringLength(50, ErrorMessage = "Số điện thoại có độ dài tối đa 50 ký tự")]
		public string phoneNumber { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
		[StringLength(100, ErrorMessage = "Tiêu đề có độ dài tối đa 100 ký tự")]
		public string title { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập nội dung")]
		[StringLength(100, ErrorMessage = "Nội dung có độ dài tối đa 100 ký tự")]
		public string detail { get; set; }
		public string remark { get; set; }
		public int typeId { get; set; }
	}
}
