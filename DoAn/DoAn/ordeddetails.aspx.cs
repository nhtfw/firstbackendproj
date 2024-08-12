using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn
{
    public partial class ordeddetails : System.Web.UI.Page
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
                        dlOrded.DataSource = kn.layDuLieu("Select * from DONHANG,SANPHAM Where TENDANGNHAP='" + tendn + "' and TRANGTHAI='mua_hang'" +
                        " and DONHANG.MASANPHAM = SANPHAM.MASANPHAM Order By MADONHANG DESC");
                        dlOrded.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Button tb = (Button)sender;
            DataListItem item = (DataListItem)tb.Parent;
            Label madh = (Label)item.FindControl("madh");


            //luu vao thong bao
            string tendn = Session["loginname"] + "";
            string mand = (string)kn.layLeDuLieu("Select MANGUOIDUNG From DONHANG Where MADONHANG='" + madh.Text + "'");
            int sl = (int)kn.layLeDuLieu("Select SOLUONG From DONHANG Where MADONHANG='" + madh.Text + "'");
            string masp = (string)kn.layLeDuLieu("Select MASANPHAM From DONHANG Where MADONHANG='" + madh.Text + "'");

            DateTime time = DateTime.Now;
            int nam = time.Year;
            int thang = time.Month;
            int ngay = time.Day;
            int gio = time.Hour;
            int phut = time.Minute;
            int giay = time.Second;
            string finaltime = $"{gio:D2}:{phut:D2}:{giay:D2} {ngay:D2}/{thang:D2}/{nam}";

            string madhstr = madh.Text;

            string tensp = (string)kn.layLeDuLieu("Select TENSANPHAM From SANPHAM Where MASANPHAM='" + masp + "'");
            kn.capNhatDuLieu("INSERT INTO THONGBAO(TIEUDE, MANGUOIDUNG, TENDANGNHAP, NOIDUNG, THOIGIAN, TRANGTHAI, MASANPHAM) VALUES" +
                    "(N'Hủy đơn hàng thành công!'," +
                    "'" + mand + "'," +
                    "'" + tendn + "'," +
                    "N'Đơn hàng " + madhstr + " với sản phẩm " + tensp + ", số lượng "+sl+" đã hủy thành công!'," +
                    "'" + finaltime + "'," +
                    "'chua_doc'," +
                    "'" + masp + "')");

            kn.capNhatDuLieu("Delete From DONHANG Where MADONHANG='" + madh.Text + "'");

            Response.Redirect("ordeddetails.aspx");
        }

        protected void btnMoreOrdedDetails_Click(object sender, EventArgs e)
        {
            Button tb = (Button)sender;
            DataListItem item = (DataListItem)tb.Parent;
            Label madh = (Label)item.FindControl("madh");

            Response.Redirect("moreordeddetails.aspx?madh=" + madh.Text);
        }
    }
}