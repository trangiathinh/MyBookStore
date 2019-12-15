using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class RecoveryAccountViewModel
    {
        //public string Email { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập mật khẩu mới",AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        [Display(Name ="Nhập mật khẩu mới")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu và xác nhận mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
    }
}