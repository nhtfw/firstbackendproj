using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class ad_layout : System.Web.UI.MasterPage
    {
        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            string tendn = Session["adminloginname"] + "";
            if (string.IsNullOrEmpty(tendn))
            {
                Response.Redirect("ad_login.aspx");
            }
            else
            {
                DataList1.DataSource = kn.layDuLieu("Select * From ADMIN Where TENDANGNHAP='" + Session["adminloginname"] + "'");
                DataList1.DataBind();
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["adminloginname"] = "";
            Response.Redirect("ad_login.aspx");
        }

    }
}