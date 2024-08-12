using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn
{
    public partial class index : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataList1.DataSource = kn.layDuLieu("Select Top 10 * From SANPHAM Where MADANHMUC='samsung'");
                DataList1.DataBind();

                DataList2.DataSource = kn.layDuLieu("Select Top 10 * From SANPHAM Where MADANHMUC='iphone'");
                DataList2.DataBind();
            }
        }


        protected void lbDeviceTitle_Click(object sender, EventArgs e)
        {
            string masp = ((LinkButton)sender).CommandArgument;
            ChuyenTrang("productdetails.aspx?masanpham=" + masp);
        }

        protected void btnDeviceImage_Command(object sender, CommandEventArgs e)
        {
            string masp = e.CommandArgument + "";
            ChuyenTrang("productdetails.aspx?masanpham=" + masp);
        }

        private void ChuyenTrang(string link)
        {
            Response.Redirect(link);
        }
    }
}