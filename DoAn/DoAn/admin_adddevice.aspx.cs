using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace DoAn
{
    public partial class admin_adddevice : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //   if (FileUpload1.HasFile)
        //   {
        //      string fileName = FileUpload1.FileName;
        //       string filePath = Server.MapPath("~/image/" + fileName);
        //       FileUpload1.SaveAs(filePath);
        //   }
        // }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string masp = tbMasanpham.Text;
            string tensp = tbTensanpham.Text;
            string mota = tbMota.Text;
            string hinh = FileUpload1.FileName;
            string dongia = tbDongia.Text;
            string danhmuc = ddlBrand.SelectedValue;

            if (!string.IsNullOrEmpty(masp) && !string.IsNullOrEmpty(tensp) && !string.IsNullOrEmpty(dongia) && !string.IsNullOrEmpty(danhmuc))
            {
                double dg = double.Parse(dongia);
                if (dg <= 0)
                {
                    lbThongBao.Text = ("Nhập đơn giá > 0");
                }
                else
                {
                    DataTable tb = kn.layDuLieu("Select * From SANPHAM Where MASANPHAM='" + masp + "'");
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        lbThongBao.Text = ("Mã sản phẩm đã được sử dụng");
                    }
                    else
                    {
                        //
                        string imgsavefinal = "";
                        if (!string.IsNullOrEmpty(hinh))
                        {
                            try
                            {
                                //tao folder
                                string folderPath = Server.MapPath("~/image/products/" + masp);
                                Directory.CreateDirectory(folderPath);

                                //luu anh
                                string filePath = Path.Combine(folderPath, hinh);
                                FileUpload1.SaveAs(filePath);

                                // lay path cua img vua tao
                                imgsavefinal = (Path.Combine("image//products", masp, hinh)).Substring(7);

                                //lbThongBao.Text = "folderPath=" + folderPath + " filePath=" + filePath + " imgsavefinal=" + imgsavefinal;

                            }
                            catch
                            {
                                imgsavefinal = "";
                            }
                        }
                        //
                        kn.capNhatDuLieu("Insert Into SANPHAM([MASANPHAM], [TENSANPHAM], [MOTA], [HINH], [DONGIA], [MADANHMUC]) " +
                    "Values('" + masp + "', '" + tensp + "', N'" + mota + "', '" + imgsavefinal + "', " + dongia + ",'" + danhmuc + "')");
                        Response.Redirect("ad_default.aspx");
                    }
                }
            }
            else
            {
                lbThongBao.Text = ("Nhập đủ thông tin cần thiết (*)");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ad_default.aspx");
        }
    }
}