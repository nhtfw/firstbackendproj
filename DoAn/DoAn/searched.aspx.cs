using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn
{
    public partial class searched : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string timkiem = Request.QueryString["search"] + "";
                lbSearched.Text = timkiem;

                DataTable tb = kn.layDuLieu("Select * From SANPHAM Where MADANHMUC like '%" + timkiem + "%' or " +
                    "TENSANPHAM like '%" + timkiem + "%'");
                if(tb!=null && tb.Rows.Count > 0)
                {
                    DataList3.DataSource = tb;
                    DataList3.DataBind();
                }
                else
                {
                    lbSearchFail.Text = "Không tìm thấy kết quả";
                }
            }
        }

        protected void btnDeviceImage_Command(object sender, CommandEventArgs e)
        {
            string masp = e.CommandArgument + "";
            Response.Redirect("productdetails.aspx?masanpham=" + masp);
        }

        protected void lbDeviceTitle_Click(object sender, EventArgs e)
        {
            string masp = ((LinkButton)sender).CommandArgument;
            Response.Redirect("productdetails.aspx?masanpham=" + masp);
        }
    }
}