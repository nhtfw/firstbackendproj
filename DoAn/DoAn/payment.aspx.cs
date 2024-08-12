using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class payment : System.Web.UI.Page
    {
        Label lbOrdCount;
        Label lbOrdTotalPrice;

        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tendn = Session["loginname"] + "";
                if (!string.IsNullOrEmpty(tendn))
                {
                    string madh = Request.QueryString["madh"] + "";
                    if (!string.IsNullOrEmpty(madh))
                    {
                        DataList1.DataSource = kn.layDuLieu("Select * From DONHANG,SANPHAM Where MADONHANG='" + madh +
                            "' And DONHANG.MASANPHAM=SANPHAM.MASANPHAM");
                        DataList1.DataBind();

                        lbDirect.Text = Request.QueryString["vanchuyen"] + "";
                        lbPhonenumber.Text = Request.QueryString["sdt"] + "";
                        lbOrdCount.Text = Request.QueryString["sl"] + "";
                        lbOrdTotalPrice.Text = Request.QueryString["tongdg"] + "";
                    }
                    else
                    {
                        string masp = Request.QueryString["masp"] + "";
                        DataList1.DataSource = kn.layDuLieu("Select * From SANPHAM Where MASANPHAM='" + masp + "'");
                        DataList1.DataBind();

                        lbDirect.Text = Request.QueryString["vanchuyen"] + "";
                        lbPhonenumber.Text = Request.QueryString["sdt"] + "";

                        //
                        float dongia = 0;
                        foreach (DataListItem item in DataList1.Items)
                        {
                            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                            {
                                // Tìm điều khiển bên trong DataList
                                Label lbOrdPrice = (Label)item.FindControl("lbOrdPrice");
                                if (lbOrdPrice != null)
                                {
                                    dongia = float.Parse(lbOrdPrice.Text);
                                }
                            }
                        }

                        //

                        lbOrdCount.Text = Request.QueryString["sl"] + "";
                        int sl = int.Parse(Request.QueryString["sl"] + "");

                        //fix loi hien thi
                        lbOrdTotalPrice.Text = (dongia * sl) + "";
                        lbOrdTotalPrice.Text = Double.Parse(lbOrdTotalPrice.Text, System.Globalization.NumberStyles.Float) + "";
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                lbOrdCount = (Label)e.Item.FindControl("lbOrdCount");
                lbOrdTotalPrice = (Label)e.Item.FindControl("lbOrdTotalPrice");
            }
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            string tendn = Session["loginname"] + "";
            DateTime time = DateTime.Now;
            int nam = time.Year;
            int thang = time.Month;
            int ngay = time.Day;
            int gio = time.Hour;
            int phut = time.Minute;
            int giay = time.Second;
            string finaltime = $"{nam}_{thang:D2}_{ngay:D2}_{gio:D2}_{phut:D2}_{giay:D2}";

            Label lbOrdName = new Label();
            foreach (DataListItem item in DataList1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    // Tìm điều khiển bên trong DataList
                    lbOrdName = (Label)item.FindControl("lbOrdName");
                }
            }

            int kq;
            string madh = Request.QueryString["madh"] + "";


            if (!string.IsNullOrEmpty(madh)) //neu da duoc vao gio hang truoc do
            {
                string note = tbNote.Text;
                if (!string.IsNullOrEmpty(note))
                {
                    kq = kn.capNhatDuLieu("Update DONHANG Set TRANGTHAI='mua_hang', GHICHU= N'"+note+"' Where MADONHANG='" + madh + "'");
                }
                else
                {
                    kq = kn.capNhatDuLieu("Update DONHANG Set TRANGTHAI='mua_hang' Where MADONHANG='" + madh + "'");
                }

                //luu vao thong bao
                string mand = (string)kn.layLeDuLieu("Select MANGUOIDUNG From DONHANG Where MADONHANG='" + madh + "'");
                int sl = (int)kn.layLeDuLieu("Select SOLUONG From DONHANG Where MADONHANG='" + madh + "'");
                string masp = (string)kn.layLeDuLieu("Select MASANPHAM From DONHANG Where MADONHANG='" + madh + "'");

                finaltime = $"{gio:D2}:{phut:D2}:{giay:D2} {ngay:D2}/{thang:D2}/{nam}";
                string tensp = lbOrdName.Text;
                kn.capNhatDuLieu("INSERT INTO THONGBAO(TIEUDE, MANGUOIDUNG, TENDANGNHAP, NOIDUNG, THOIGIAN, TRANGTHAI, MASANPHAM) VALUES" +
                        "(N'Đặt hàng thành công!'," +
                        "'" + mand + "'," +
                        "'" + tendn + "'," +
                        "N'Đơn hàng " + madh + " với sản phẩm " + tensp + " với số lượng " + sl + " đã được đặt hàng thành công!'," +
                        "'" + finaltime + "'," +
                        "'chua_doc'," +
                        "'" + masp + "')");
            }
            else
            {
                madh = "DH_" + tendn + "_" + finaltime;
                string mand = (string)kn.layLeDuLieu("Select MANGUOIDUNG From NGUOIDUNG Where TENDANGNHAP='" + tendn + "'");
                string masp = Request.QueryString["masp"] + "";
                int sl = int.Parse(Request.QueryString["sl"] + "");

                string diachi = Request.QueryString["vanchuyen"] + "";
                string sdt = Request.QueryString["sdt"] + "";

                string note = tbNote.Text;

                float tongdongia = 0;
                foreach (DataListItem item in DataList1.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        // Tìm điều khiển bên trong DataList
                        Label lbOrdTotalPrice2 = (Label)item.FindControl("lbOrdTotalPrice");
                        if (lbOrdTotalPrice2 != null)
                        {
                            tongdongia = float.Parse(lbOrdTotalPrice2.Text);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(note))
                {
                    kq = kn.capNhatDuLieu("INSERT INTO [dbo].[DONHANG] ([MADONHANG], [MANGUOIDUNG], [TENDANGNHAP], [MASANPHAM], [SOLUONG], [TONGDONGIA], [TRANGTHAI], [DIACHI], [SODIENTHOAI], [GHICHU])" +
                               "VALUES('" + madh + "', '" + mand + "', '" + tendn + "', '" + masp + "', " + sl + ", " + tongdongia + " , 'mua_hang', N'" + diachi + "', '" + sdt + "', N'" + note + "')");
                }

                kq = kn.capNhatDuLieu("INSERT INTO [dbo].[DONHANG] ([MADONHANG], [MANGUOIDUNG], [TENDANGNHAP], [MASANPHAM], [SOLUONG], [TONGDONGIA], [TRANGTHAI], [DIACHI], [SODIENTHOAI])" +
                               "VALUES('" + madh + "', '" + mand + "', '" + tendn + "', '" + masp + "', " + sl + ", " + tongdongia + " , 'mua_hang', N'" + diachi + "', '" + sdt + "')");

                //tao thong bao
                finaltime = $"{gio:D2}:{phut:D2}:{giay:D2} {ngay:D2}/{thang:D2}/{nam}";
                string tensp = lbOrdName.Text;
                kn.capNhatDuLieu("INSERT INTO THONGBAO(TIEUDE, MANGUOIDUNG, TENDANGNHAP, NOIDUNG, THOIGIAN, TRANGTHAI, MASANPHAM) VALUES" +
                        "(N'Đặt hàng thành công!'," +
                        "'" + mand + "'," +
                        "'" + tendn + "'," +
                        "N'Đơn hàng "+madh+" với sản phẩm " + tensp + ", số lượng " + sl + " đã được đặt hàng thành công!'," +
                        "'" + finaltime + "'," +
                        "'chua_doc'," +
                        "'" + masp + "')");
            }
            if (kq > 0)
            {
                Response.Redirect("buysuccess.aspx");
            }
        }
    }
}