using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.model.member
{
    /// <summary>
    /// 会员信息实体
    /// </summary>
    class memberInfo
    {
        private int memberId;
        private string nickName;    //昵称
        private string account;     //账号
        private string password;    //密码
        private string realName;
        private string regtime;     //注册时间
        private string activation;
        private string headportraiturl;
        private int bindstoreId;    //绑定购买东西时的店铺id
        private int storeFlag;  //是否是店铺的标识  1. 是店铺  2. 不是店铺
        private int storeId;     //storeFlag 为1 时，才处理这个字段，绑定店铺，也就是这个会员是店铺
        private string token;   //用户登录后生成的唯一识别码；每次登录后重新生成
        private string payPw;   //用户设置的支付密码
        private int vipStatu;   //是否为vip; 默认1不是；2是；
        private int partnerStatu;   //是否为店铺合伙人；默认1不是；2是
        private int storeAuthStatu; //是否已经被店铺授权； 默认1没有； 2有

        public int MemberId { get => memberId; set => memberId = value; }
        public string NickName { get => nickName; set => nickName = value; }
        public string Account { get => account; set => account = value; }
        public string Password { get => password; set => password = value; }
        public string RealName { get => realName; set => realName = value; }
        public string Regtime { get => regtime; set => regtime = value; }
        public string Activation { get => activation; set => activation = value; }
        public string Headportraiturl { get => headportraiturl; set => headportraiturl = value; }
        public int BindstoreId { get => bindstoreId; set => bindstoreId = value; }
        public int StoreFlag { get => storeFlag; set => storeFlag = value; }
        public int StoreId { get => storeId; set => storeId = value; }
        public string Token { get => token; set => token = value; }
        public string PayPw { get => payPw; set => payPw = value; }
        public int VipStatu { get => vipStatu; set => vipStatu = value; }
        public int PartnerStatu { get => partnerStatu; set => partnerStatu = value; }
        public int StoreAuthStatu { get => storeAuthStatu; set => storeAuthStatu = value; }
    }
}
