using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace DoAn
{
    public partial class NestedUserdetails : System.Web.UI.MasterPage
    {
        LopKetNoi kn = new LopKetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tendn = Session["loginname"] + "";
                if (!string.IsNullOrEmpty(tendn))
                {
                    DataTable dt = kn.layDuLieu("Select * From NGUOIDUNG Where TENDANGNHAP='" + tendn + "'");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dlUser.DataSource = dt;
                        dlUser.DataBind();

                        // dlOrded.DataSource = kn.layDuLieu("Select * from DONHANG,SANPHAM Where TENDANGNHAP='" + tendn + "' and TRANGTHAI='mua_hang'" +
                        //  " and DONHANG.MASANPHAM = SANPHAM.MASANPHAM");
                        //  dlOrded.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}