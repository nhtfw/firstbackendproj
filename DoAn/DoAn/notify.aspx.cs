using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class notify : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataList1.DataSource = kn.layDuLieu("Select THONGBAO.*, SANPHAM.HINH From THONGBAO,SANPHAM Where THONGBAO.MASANPHAM=SANPHAM.MASANPHAM and " +
                    "TENDANGNHAP='"+Session["loginname"] + "' Order By THOIGIAN DESC");
                DataList1.DataBind();

                kn.capNhatDuLieu("UPDATE THONGBAO Set TRANGTHAI='da_doc' where TRANGTHAI='chua_doc'");
            }
        }

        protected void btnDeleteNoti_Click(object sender, EventArgs e)
        {
            string tg = ((ImageButton)sender).CommandArgument;

            kn.capNhatDuLieu("Delete from THONGBAO Where THOIGIAN='" + tg + "'");

            Response.Redirect("notify.aspx");
        }
    }
}