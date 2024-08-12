using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class cart : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        //TextBox tbCount;
        //Label lbmadh;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tendn = Session["loginname"] + "";
                if (!string.IsNullOrEmpty(tendn))
                {
                    DataList1.DataSource = kn.layDuLieu("Select * from DONHANG,SANPHAM Where TENDANGNHAP='" + tendn + "' and TRANGTHAI='gio_hang'" +
                        " and DONHANG.MASANPHAM = SANPHAM.MASANPHAM");
                    DataList1.DataBind();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //   {
            //        tbCount = (TextBox)e.Item.FindControl("tbCount");
            //       lbmadh = (Label)e.Item.FindControl("madh");
            //         //tbCount = (TextBox)e.Item.FindControl("tbCount");
            //     }
        }


        protected void tbCount_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            DataListItem item = (DataListItem)tb.Parent;
            TextBox tbCount = (TextBox)item.FindControl("tbCount");

            string slstr = tbCount.Text;
            if (!string.IsNullOrEmpty(slstr))
            {
                int sl = int.Parse(slstr);
                if (!(sl <= 0))
                {
                    Label madh = (Label)item.FindControl("madh");
                    Label lbPrice = (Label)item.FindControl("lbPrice");
                    float dongia = float.Parse(lbPrice.Text);

                    kn.capNhatDuLieu("Update DONHANG Set SOLUONG=" + sl + ", TONGDONGIA=" + dongia + "*" + sl + " Where MADONHANG='" + madh.Text + "'" +
                        "");
                }
            }

            Response.Redirect("cart.aspx");
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton tb = (ImageButton)sender;
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

            string tensp = (string)kn.layLeDuLieu("Select TENSANPHAM From SANPHAM Where MASANPHAM='" + masp + "'");
            kn.capNhatDuLieu("INSERT INTO THONGBAO(TIEUDE, MANGUOIDUNG, TENDANGNHAP, NOIDUNG, THOIGIAN, TRANGTHAI, MASANPHAM) VALUES" +
                    "(N'Xóa sản phẩm khỏi giỏ hàng thành công!'," +
                    "'" + mand + "'," +
                    "'" + tendn + "'," +
                    "N'Sản phẩm " + tensp + " với số lượng " + sl + " đã được xóa khỏi giỏ hàng thành công!'," +
                    "'" + finaltime + "'," +
                    "'chua_doc'," +
                    "'" + masp + "')");


            kn.capNhatDuLieu("Delete From DONHANG Where MADONHANG='" + madh.Text + "'");

            Response.Redirect("cart.aspx");
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            string madh = ((Button)sender).CommandArgument;
            string vanchuyen = (string) kn.layLeDuLieu("Select DIACHI From DONHANG Where MADONHANG='"+madh+"'");
            string sdt = (string)kn.layLeDuLieu("Select SODIENTHOAI From DONHANG Where MADONHANG='" + madh + "'");
            int sl = (int)kn.layLeDuLieu("Select SOLUONG From DONHANG Where MADONHANG='" + madh + "'");

            double tongdg = (double)kn.layLeDuLieu("Select TONGDONGIA From DONHANG Where MADONHANG='" + madh + "'");

            Response.Redirect("payment.aspx?madh="+madh+"&vanchuyen="+vanchuyen+"&sdt="+sdt+"&sl="+sl+"&tongdg="+tongdg);
        }
    }
}