using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn
{
    public partial class ad_login : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string tendn = tbAdminName.Text;
                string mk = tbPassword.Text;

                string sql = "Select * From ADMIN Where TENDANGNHAP='" + tendn + "' And MATKHAU='" + mk + "'";
                DataTable dt = kn.layDuLieu(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["adminloginname"] = tendn;
                    Response.Redirect("ad_default.aspx");
                }
                else
                {
                    lbThongBao.Text = "Đã xảy ra lỗi";
                }
            }
        }
    }
}