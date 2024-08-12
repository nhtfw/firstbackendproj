using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn
{
    public partial class layout : System.Web.UI.MasterPage
    {
        LopKetNoi kn = new LopKetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tendn = Session["loginname"] + "";
                checklogin.Text = tendn;
                DataTable dt = kn.layDuLieu("Select TENNGUOIDUNG From NGUOIDUNG Where TENDANGNHAP='" + tendn + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    dlUser.DataSource = dt;
                    dlUser.DataBind();

                    //count noti
                    Label lbCountNoti = new Label();
                    foreach (DataListItem item in dlUser.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            // Tìm điều khiển bên trong DataList
                            lbCountNoti = (Label)item.FindControl("lbCountNoti");
                        }
                    }

                    int count =(int) kn.layLeDuLieu("Select Count(MANGUOIDUNG) From THONGBAO Where TRANGTHAI='chua_doc' and TENDANGNHAP='"+tendn+"'");

                    lbCountNoti.Text = count+"";

                }
            }
        }

        protected void lbusername_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Redirect("userdetails.aspx");
            }
        }

        protected void imgNotify_Click(object sender, EventArgs e)
        {
            Response.Redirect("notify.aspx");
        }

        protected void logoutlink_Click(object sender, EventArgs e)
        {
            Session["loginname"] = "";
            Response.Redirect("default.aspx");
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string timkiem = tbSearch.Text;
            if (!string.IsNullOrEmpty(timkiem))
            {
                Response.Redirect("searched.aspx?search=" + timkiem);
            }
        }

        protected void btnCart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cart.aspx");
        }

        protected void lbIphone_Click(object sender, EventArgs e)
        {
            Response.Redirect("brand.aspx?madm=" + "iphone");
        }

        protected void lbOppo_Click(object sender, EventArgs e)
        {
            Response.Redirect("brand.aspx?madm=" + "oppo");
        }

        protected void lbRealme_Click(object sender, EventArgs e)
        {
            Response.Redirect("brand.aspx?madm=" + "realme");
        }

        protected void lbRedmi_Click(object sender, EventArgs e)
        {
            Response.Redirect("brand.aspx?madm=" + "vivo");
        }

        protected void lbSamsung_Click(object sender, EventArgs e)
        {
            Response.Redirect("brand.aspx?madm=" + "samsung");
        }

        protected void lbXiaomi_Click(object sender, EventArgs e)
        {
            Response.Redirect("brand.aspx?madm=" + "xiaomi");
        }
    }
}