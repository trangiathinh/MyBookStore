using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên không được rỗng", AllowEmptyStrings = false)]
        [MaxLength(50, ErrorMessage = "Họ tên không được quá 50 ký tự")]
        [MinLength(3, ErrorMessage = "Họ tên phải chứa ít nhất 3 ký tự")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được rỗng", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage = "Mật không được rỗng", AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage ="Mật khẩu phải chứa ít nhất 8 ký tự")]
        [MaxLength(20, ErrorMessage = "Mật khẩu không được quá 20 ký tự")]
        public string Password { get; set; }


        [Display(Name ="Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }

        [Display(Name="Ngày sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Vui lòng chọn Ngày sinh")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage ="Số điện thoại không được rỗng",AllowEmptyStrings =false)]
        [MaxLength(15, ErrorMessage ="Số điện thoại không được quá 15 ký tự")]
        [MinLength(10, ErrorMessage ="Số điện thoại phải chứa ít nhất 10 ký tự")]
        [Phone(ErrorMessage ="Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }
    }
}