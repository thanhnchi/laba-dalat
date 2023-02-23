using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebAdmin_Corporate.Models
{
    public class M_Account
    {
        public int? id { get; set; }
        public string userName { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string accountType { get; set; }
        public string avatar { get; set; }
    }
    public class M_AccountSignIn
    {
        public int? id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string accountType { get; set; }
        public int systemId { get; set; }
        public int? personId { get; set; }
        public string access_token { get; set; }
    }
    public class EM_AccountSignIn
    {
        [Required(ErrorMessage = "Nhập tài khoản")]
        [RegularExpression("^[a-z0-9_-]{3,50}$", ErrorMessage = "Tài khoản không hợp lệ")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [RegularExpression(@"^([^'ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêếìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳýỵỷỹ\-\s]+)$", ErrorMessage = "Mật khẩu không được chứa ký tự dấu và khoảng trắng.")]
        public string password { get; set; }
        public bool stayLoggedIn { get; set; }
        public string deviceToken { get; set; }
    }
    public class EM_AccountRegister
    {
        [Required(ErrorMessage = "Nhập tài khoản")]
        [RegularExpression("^[a-z0-9_-]{3,50}$", ErrorMessage = "Tài khoản không hợp lệ")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [RegularExpression(@"^([^'ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêếìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳýỵỷỹ\-\s]+)$", ErrorMessage = "Mật khẩu không được chứa ký tự dấu và khoảng trắng.")]
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string avatarUrl { get; set; }
    }
    public class EM_AccountUpdate
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Nhập tài khoản")]
        [RegularExpression("^[a-z0-9_-]{3,50}$", ErrorMessage = "Tài khoản không hợp lệ")]
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string avatarUrl { get; set; }
    }
}
