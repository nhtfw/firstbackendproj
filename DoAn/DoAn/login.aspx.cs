using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn
{
    public partial class login2 : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string tendn = tbTenDangNhap.Text;
                string mk = tbMatKhau.Text;
                string sql = "Select * From NGUOIDUNG Where TENDANGNHAP='" + tendn + "' And MATKHAU='" + mk + "'";
                DataTable dt = kn.layDuLieu(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["loginname"] = tendn;
                    Response.Redirect("default.aspx");
                }
                else
                {
                    lbThongBao.Text = "Đã xảy ra lỗi";
                }
            }
        }
    }
}