using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class brand : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string madm = Request.QueryString["madm"] + "";
                DataList3.DataSource = kn.layDuLieu("Select * From SANPHAM where MADANHMUC='"+madm+"'");
                DataList3.DataBind();
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