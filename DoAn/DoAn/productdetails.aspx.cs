using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DoAn
{
    public partial class productdetails : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        TextBox tbTrans = new TextBox();
        TextBox tbPhoneNumber = new TextBox();
        TextBox tbCount = new TextBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            load();
            if (!IsPostBack)
            {
                string masp = Request.QueryString["masanpham"] + "";
                if (!string.IsNullOrEmpty(masp))
                {
                    DataList1.DataSource = kn.layDuLieu("Select * From SANPHAM Where MASANPHAM='" + masp + "'");
                    DataList1.DataBind();

                    DataList2.DataSource = kn.layDuLieu("Select * From SANPHAM Where MASANPHAM='" + masp + "'");
                    DataList2.DataBind();

                    DataList3.DataSource = kn.layDuLieu("Select top 5 * From SANPHAM Where MASANPHAM<>'" + masp + "'");
                    DataList3.DataBind();
                }

                string tendn = Session["loginname"] + "";
                if (!string.IsNullOrEmpty(tendn))
                {
                    string trans = (string)kn.layLeDuLieu("Select DIACHI From NGUOIDUNG Where TENDANGNHAP='" + tendn + "'");
                    tbTrans.Text = trans;

                    string phone = (string)kn.layLeDuLieu("Select SODIENTHOAI From NGUOIDUNG Where TENDANGNHAP='" + tendn + "'");
                    tbPhoneNumber.Text = phone;
                }
            }
        }

        protected void load()
        {
            foreach (DataListItem item in DataList1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    // Tìm điều khiển bên trong DataList
                    tbTrans = (TextBox)item.FindControl("tbTrans");
                    tbPhoneNumber = (TextBox)item.FindControl("tbPhoneNumber");
                    tbCount = (TextBox)item.FindControl("tbCount");
                }
            }
        }

        //Sự kiện này xảy ra khi mỗi item trong DataList1 được liên kết với dữ liệu.
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                tbTrans = (TextBox)e.Item.FindControl("tbTrans");
                tbPhoneNumber = (TextBox)e.Item.FindControl("tbPhoneNumber");
                //tbCount = (TextBox)e.Item.FindControl("tbCount");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string tendn = Session["loginname"] + "";

            if (!string.IsNullOrEmpty(tendn)) //neu da dang nhap
            {
                DateTime time = DateTime.Now;
                int nam = time.Year;
                int thang = time.Month;
                int ngay = time.Day;
                int gio = time.Hour;
                int phut = time.Minute;
                int giay = time.Second;
                string finaltime = $"{nam}_{thang:D2}_{ngay:D2}_{gio:D2}_{phut:D2}_{giay:D2}";

                string madh = "DH_" + tendn + "_" + finaltime;
                string mand = (string)kn.layLeDuLieu("Select MANGUOIDUNG From NGUOIDUNG Where TENDANGNHAP='" + tendn + "'");
                string masp = Request.QueryString["masanpham"] + "";

                Button bt = (Button)sender;
                DataListItem item = (DataListItem)bt.Parent;
                TextBox tbCount = (TextBox)item.FindControl("tbCount");

                int soluong = int.Parse(tbCount.Text);

                if (soluong <= 0) // neu nguoi dung k ghi so
                {
                    soluong = 1;
                }

                object obj = kn.layLeDuLieu("Select DONGIA From SANPHAM Where MASANPHAM='" + masp + "'");

                float dongia = float.Parse(obj.ToString());

                float tongdongia = dongia * soluong;

                TextBox trans = (TextBox)item.FindControl("tbTrans");
                string diachi = trans.Text;

                TextBox tbsdt = (TextBox)item.FindControl("tbPhoneNumber");
                string sdt = tbsdt.Text;

                int kq = kn.capNhatDuLieu("INSERT INTO [dbo].[DONHANG] ([MADONHANG], [MANGUOIDUNG], [TENDANGNHAP], [MASANPHAM], [SOLUONG], [TONGDONGIA], [TRANGTHAI], [DIACHI], [SODIENTHOAI], [GHICHU])" +
                           "VALUES('" + madh + "', '" + mand + "', '" + tendn + "', '" + masp + "', " + soluong + ", " + tongdongia + " , 'gio_hang', N'" + diachi + "', '" + sdt + "', '')");

                if (kq > 0)//kq thanh cong
                {
                    Label lbThongBao = new Label();

                    foreach (DataListItem item2 in DataList1.Items)
                    {
                        if (item2.ItemType == ListItemType.Item || item2.ItemType == ListItemType.AlternatingItem)
                        {
                            // Tìm điều khiển bên trong DataList
                            lbThongBao = (Label)item.FindControl("lbThongBao");
                        }
                    }

                    string tensp = (string)kn.layLeDuLieu("Select TENSANPHAM From SANPHAM Where MASANPHAM='" + masp + "'");

                    //them vao thong bao
                    finaltime = $"{gio:D2}:{phut:D2}:{giay:D2} {ngay:D2}/{thang:D2}/{nam}";

                    kn.capNhatDuLieu("INSERT INTO THONGBAO(TIEUDE, MANGUOIDUNG, TENDANGNHAP, NOIDUNG, THOIGIAN, TRANGTHAI, MASANPHAM) VALUES" +
                        "(N'Thêm vào giỏ hàng thành công!'," +
                        "'" + mand + "'," +
                        "'" + tendn + "'," +
                        "N'Sản phẩm " + tensp + " với số lượng " + soluong + " được thêm vào giỏ hàng thành công!'," +
                        "'" + finaltime + "'," +
                        "'chua_doc'," +
                        "'" + masp + "')");

                    ChuyenTrang("addtocartsuccess.aspx");
                }
            }
            else //neu chua dang nhap
            {
                ChuyenTrang("login.aspx");
            }


        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            string masp = Request.QueryString["masanpham"] + "";

            Button bt = (Button)sender;
            DataListItem item = (DataListItem)bt.Parent;
            TextBox trans = (TextBox)item.FindControl("tbTrans");
            string vanchuyen = trans.Text;

            TextBox tbsdt = (TextBox)item.FindControl("tbPhoneNumber");
            string sdt = tbsdt.Text;

            TextBox tbCount = (TextBox)item.FindControl("tbCount");
            string sl = tbCount.Text;

            ChuyenTrang("payment.aspx?masp=" + masp + "&vanchuyen=" + vanchuyen + "&sdt=" + sdt + "&sl=" + sl);
        }

        protected void lbDeviceTitle_Click(object sender, EventArgs e)
        {
            string masp = ((LinkButton)sender).CommandArgument;
            ChuyenTrang("productdetails.aspx?masanpham=" + masp);
        }

        protected void btnDeviceImage_Click(object sender, ImageClickEventArgs e)
        {
            string masp = ((ImageButton)sender).CommandArgument;
            ChuyenTrang("productdetails.aspx?masanpham=" + masp);
        }



        private void ChuyenTrang(string link)
        {
            Response.Redirect(link);
        }

        protected void tbTrans_TextChanged(object sender, EventArgs e)
        {
            string diachi = tbTrans.Text;
            if (string.IsNullOrEmpty(diachi))
            {
                tbTrans.Text = (string)kn.layLeDuLieu("Select DIACHI From NGUOIDUNG Where TENDANGNHAP='" + Session["loginname"] + "'");
            }
        }

        protected void tbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            string sdt = tbPhoneNumber.Text;
            if (string.IsNullOrEmpty(sdt))
            {
                tbTrans.Text = (string)kn.layLeDuLieu("Select SODIENTHOAI From NGUOIDUNG Where TENDANGNHAP='" + Session["loginname"] + "'");
            }
        }

        protected void tbCount_TextChanged(object sender, EventArgs e)
        {
            string sl = tbCount.Text;
            if (string.IsNullOrEmpty(sl))
            {
                tbCount.Text = "1";
            }
            else
            {
                int sl2 = int.Parse(sl);
                if (sl2 <= 0)
                {
                    tbCount.Text = "1";
                }
            }
        }
    }
}