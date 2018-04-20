using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.store
{
    public partial class frmStoreAndMember : Form
    {
        public frmStoreAndMember()
        {
            InitializeComponent();
        }

        private void frmStoreAndMember_Load(object sender, EventArgs e)
        {
            JObject json  =  service.store_service.storeInfoService.queryBindStoreMemberCount();
            this.vipSum.Text = json["vipSum"].ToString();
            this.partnerSum.Text = json["partnerSum"].ToString();
            this.bindSum.Text = json["bindSum"].ToString();
        }
    }
}
