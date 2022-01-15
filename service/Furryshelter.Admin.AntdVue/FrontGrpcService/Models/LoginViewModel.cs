using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontGrpcService.Models
{
    /// <summary>
    /// 注册请求参数
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// 用户名 邮箱
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password",
            ErrorMessage = "密码与确认密码不一致，请重新输入.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public string EmailValidateCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }
 
        /// <summary>
        /// 姓名
        /// </summary>
        public String RealName { get; set; }

        /// <summary>
        /// 性别(1为男，0为女)
        /// </summary>
        public Int32 Sex { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        /// 身份证实名
        /// </summary>
        public String IdentityCardNo { get; set; }

        /// <summary>
        /// 否已实名
        /// </summary>
        public Boolean IfVerifyCardNo { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public String Birthday { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public String Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public String City { get; set; }

        /// <summary>
        /// 否已养宠物
        /// </summary>
        public Boolean IfPet { get; set; }
    }

    /// <summary>
    /// 登录参数
    /// </summary>
    public class LoginViewModel
    {

        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }
    }
}
