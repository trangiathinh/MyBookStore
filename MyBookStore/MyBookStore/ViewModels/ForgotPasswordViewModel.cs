using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="Vui lòng điền email để khôi phục mật khẩu")]
        [Display(Name ="Nhập Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}