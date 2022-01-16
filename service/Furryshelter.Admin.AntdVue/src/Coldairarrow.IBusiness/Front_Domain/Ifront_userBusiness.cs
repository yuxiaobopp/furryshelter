using Coldairarrow.Entity.Front_Domain;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Front_Domain
{
    public interface Ifront_userBusiness
    {
        Task<PageResult<front_user>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<front_user> GetTheDataAsync(string id);
        Task AddDataAsync(front_user data);
        Task UpdateDataAsync(front_user data);
        Task DeleteDataAsync(List<string> ids);
        Task<front_user> FindDataByEmailAsync(string email);
        Task<string> SubmitLoginAsync(front_user_loginDTO input);
        Task ChangePwdAsync(front_user_changepwdDTO input);
    }

    /// <summary>
    /// 注册、登录 返回结果code
    /// </summary>
    public enum FrontUserRegistResult
    {
        成功 = 1,
        注册失败 = -1,
        邮箱已经存在 = -2,
        两次密码不一致 = -3,
        参数错误 = -4,
        邮箱不存在 = -5,
        邮箱验证码错误 = -6,
    }

    /// <summary>
    /// 邮箱验证实体
    /// </summary>
    public class front_user_emailDTO
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        [Required]
        public String EmailCode { get; set; }
    }

    /// <summary>
    /// 登录实体
    /// </summary>
    public class front_user_loginDTO
    {
        /// <summary>
        /// 用户名 
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
      
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    public class front_user_changepwdDTO
    {
        /// <summary>
        /// 用户名 
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        /// <summary>
        /// 当前密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string OldPwd { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string NewPwd { get; set; }

    }
    /// <summary>
    /// 用户信息接口请求参数
    /// </summary>
    public class front_userDTO
    {
        /// <summary>
        /// 用户名 
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
        [Required]
        public String Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Required]
        public String City { get; set; }

        /// <summary>
        /// 否已养宠物
        /// </summary>
        public Boolean IfPet { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public String EmailCode { get; set; }

        /// <summary>
        /// 否已验证邮箱
        /// </summary>
        public Boolean IfVeryfyEmail { get; set; }
    }
}