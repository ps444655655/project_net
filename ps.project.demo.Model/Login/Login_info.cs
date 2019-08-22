using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrameWorkStd.Base.Model;

namespace ps.project.demo.Model
{
    /// <summary>
    /// 用户登录
    /// 创建人:彭帅
    /// 创建时间:2019/8/22 星期四
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Table("Login_info")]
    public partial class Login_info : BaseModel
	{        
        
        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        [DataMember()]
        [Column("AccountNum")]
        public virtual string AccountNum { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [DataMember()]
        [Column("Password")]
        public virtual string Password { get; set; }
    }
}
