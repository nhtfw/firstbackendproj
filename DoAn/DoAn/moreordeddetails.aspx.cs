using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn
{
    public partial class moreordeddetails : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string madh = Request.QueryString["madh"] + "";

                DataList1.DataSource = kn.layDuLieu("Select * from DONHANG,SANPHAM Where MADONHANG='" + madh + "'" +
                        " and DONHANG.MASANPHAM = SANPHAM.MASANPHAM");
                DataList1.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string madh = Request.QueryString["madh"] + "";

            //luu vao thong bao
            string tendn = Session["loginname"] + "";
            string mand = (string)kn.layLeDuLieu("Select MANGUOIDUNG From DONHANG Where MADONHANG='" + madh + "'");
            int sl = (int)kn.layLeDuLieu("Select SOLUONG From DONHANG Where MADONHANG='" + madh + "'");
            string masp = (string)kn.layLeDuLieu("Select MASANPHAM From DONHANG Where MADONHANG='" + madh + "'");

            DateTime time = DateTime.Now;
            int nam = time.Year;
            int thang = time.Month;
            int ngay = time.Day;
            int gio = time.Hour;
            int phut = time.Minute;
            int giay = time.Second;
            string finaltime = $"{gio:D2}:{phut:D2}:{giay:D2} {ngay:D2}/{thang:D2}/{nam}";

            string madhstr = madh;

            string tensp = (string)kn.layLeDuLieu("Select TENSANPHAM From SANPHAM Where MASANPHAM='" + masp + "'");
            kn.capNhatDuLieu("INSERT INTO THONGBAO(TIEUDE, MANGUOIDUNG, TENDANGNHAP, NOIDUNG, THOIGIAN, TRANGTHAI, MASANPHAM) VALUES" +
                    "(N'Hủy đơn hàng thành công!'," +
                    "'" + mand + "'," +
                    "'" + tendn + "'," +
                    "N'Đơn hàng " + madhstr + " với sản phẩm " + tensp + ", số lượng " + sl + " đã hủy thành công!'," +
                    "'" + finaltime + "'," +
                    "'chua_doc'," +
                    "'" + masp + "')");

            kn.capNhatDuLieu("Delete From DONHANG Where MADONHANG='" + madh + "'");

            Response.Redirect("ordeddetails.aspx");
        }
    }
}