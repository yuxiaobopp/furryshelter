using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Front_Domain
{
    /// <summary>
    /// C端用户表
    /// </summary>
    [Table("front_user")]
    public class front_user
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

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
        /// 用户名邮箱形式
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }

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
}