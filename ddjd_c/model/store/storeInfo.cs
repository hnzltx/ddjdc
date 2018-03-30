using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.model.store
{
    /// <summary>
    /// 店铺信息实体
    /// </summary>
    class storeInfo
    {

        private int storeId;
        private string storeName;
        private string ownerName;
        private string tel; //联系电话
        private string applyRemark; //店铺描述
        private string ctime;   //创建时间
        private int state;  //状态 开启-1；关闭-2
        private string address; //详细地址
        private string storeQRcode; //店铺二维码
        private int distributionScope;  //配送范围（Km）
        private int lowestMoney;    //店铺设置的最低起送额； 整数
        private string distributionStartTime;   //配送时间范围；开始时间
        private string distributionEndTime;     //配送时间范围；结束时间
        private string storeMsg;    //老板留言； 展示在消费者端
        private int bindFlag;   //是否被会员绑定了 1. 未绑定 2. 绑定
        private string lat; //纬度
        private string lon; //经度
        private int openFlag;   //店铺是否开启, 店铺自己可以改状态的哦 1 开启 ， 2 关闭
        private string deliveryFee; //配送费
        private int partnerMaxCount; //此店铺最多可以增加多少个合伙人
        private int memberDiscount; //会员折扣； 95折填95
        private int? substationId;   //所属分站
        private int storeType;  //店铺类型 1. 直营 2. 加盟
        private int? provinceId;
        private int? cityId;
        private int? countyId;
        private string provinceText;
        private string cityText;
        private string countyText;


        public int StoreId { get => storeId; set => storeId = value; }
        public string StoreName { get => storeName; set => storeName = value; }
        public string ProvinceText { get => provinceText; set => provinceText = value; }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        public string Tel { get => tel; set => tel = value; }
        public string ApplyRemark { get => applyRemark; set => applyRemark = value; }
        public string Ctime { get => ctime; set => ctime = value; }
        public int State { get => state; set => state = value; }
        public string Address { get => address; set => address = value; }
        public string StoreQRcode { get => storeQRcode; set => storeQRcode = value; }
        public int DistributionScope { get => distributionScope; set => distributionScope = value; }
        public int LowestMoney { get => lowestMoney; set => lowestMoney = value; }
        public string DistributionStartTime { get => distributionStartTime; set => distributionStartTime = value; }
        public string DistributionEndTime { get => distributionEndTime; set => distributionEndTime = value; }
        public string StoreMsg { get => storeMsg; set => storeMsg = value; }
        public int BindFlag { get => bindFlag; set => bindFlag = value; }
        public string Lat { get => lat; set => lat = value; }
        public string Lon { get => lon; set => lon = value; }
        public int OpenFlag { get => openFlag; set => openFlag = value; }
        public int PartnerMaxCount { get => partnerMaxCount; set => partnerMaxCount = value; }
        public int MemberDiscount { get => memberDiscount; set => memberDiscount = value; }

        public int StoreType { get => storeType; set => storeType = value; }
        public int? ProvinceId { get => provinceId; set => provinceId = value; }
        public int? CityId { get => cityId; set => cityId = value; }
        public int? CountyId { get => countyId; set => countyId = value; }
        public string CityText { get => cityText; set => cityText = value; }
        public string CountyText { get => countyText; set => countyText = value; }
        public string DeliveryFee { get => deliveryFee; set => deliveryFee = value; }
        public int? SubstationId { get => substationId; set => substationId = value; }
    }
}
