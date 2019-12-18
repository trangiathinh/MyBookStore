using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email không được rỗng",AllowEmptyStrings =false)]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        //[Required(ErrorMessage ="Mật khẩu không được rỗng",AllowEmptyStrings =false),
        //MinLength(8,ErrorMessage ="Mật khẩu phải chứa ít nhất 8 ký tự"),
        //MaxLength(20, ErrorMessage ="Mật khẩu không được quá 20 ký tự")]
        public string Password { get; set; }
        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set; } = false;
    }
}