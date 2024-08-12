using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DoAn
{
    public partial class ad_editdevice : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string masp = Request.QueryString["masp"];

                DataList1.DataSource = kn.layDuLieu("Select * From SANPHAM Where MASANPHAM='" + masp + "'");
                DataList1.DataBind();

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Image tbHinh = new Image();

            TextBox tbTensanpham = new TextBox();
            TextBox tbMota = new TextBox();
            FileUpload FileUpload1 = new FileUpload();
            TextBox tbDongia = new TextBox();
            DropDownList ddlBrand = new DropDownList();
            Label lbThongBao = new Label();

            Label tbMasanpham = new Label();

            foreach (DataListItem item in DataList1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    tbHinh = (Image)item.FindControl("tbHinh");

                    tbTensanpham = (TextBox)item.FindControl("tbTensanpham");
                    tbMota = (TextBox)item.FindControl("tbMota");
                    FileUpload1 = (FileUpload)item.FindControl("FileUpload1");
                    tbDongia = (TextBox)item.FindControl("tbDongia");
                    ddlBrand = (DropDownList)item.FindControl("ddlBrand");
                    lbThongBao = (Label)item.FindControl("lbThongBao");

                    tbMasanpham = (Label)item.FindControl("tbMasanpham");
                }
            }
            string hinh = FileUpload1.FileName;

            string tensp = tbTensanpham.Text;
            string mota = tbMota.Text;
            string dongia = tbDongia.Text;
            string danhmuc = ddlBrand.SelectedValue;

            string masp = tbMasanpham.Text;

            if (!string.IsNullOrEmpty(tensp) && !string.IsNullOrEmpty(dongia) && !string.IsNullOrEmpty(danhmuc))
            {
                //neu nhap khong du, se bat buoc nhap

                //bat buoc nhap don gia > 0
                double dg = double.Parse(dongia);
                if (dg <= 0)
                {
                    lbThongBao.Text = ("Nhập đơn giá > 0");
                }
                else
                {
                    string premasp = Request.QueryString["masp"];
                    int kq = kn.capNhatDuLieu("Update SANPHAM Set TENSANPHAM='" + tensp + "' Where MASANPHAM='" + premasp + "'");
                    kq = kn.capNhatDuLieu("Update SANPHAM Set MOTA=N'" + mota + "' Where MASANPHAM='" + premasp + "'");
                    kq = kn.capNhatDuLieu("Update SANPHAM Set DONGIA=" + dongia + " Where MASANPHAM='" + premasp + "'");
                    kq = kn.capNhatDuLieu("Update SANPHAM Set MADANHMUC='" + danhmuc + "' Where MASANPHAM='" + premasp + "'");

                    if (!string.IsNullOrEmpty(hinh))//neu nguoi dung chon anh moi
                    {
                        try
                        {
                            //kiem tra su ton tai cua folder

                            string folderPath = Server.MapPath("~/image/products/" + masp);
                            if (Directory.Exists(folderPath))
                            {
                                //xoa folder da co truoc do
                                Directory.Delete(folderPath, true);
                            }

                            //tao folder
                            folderPath = Server.MapPath("~/image/products/" + masp);
                            Directory.CreateDirectory(folderPath);

                            //luu anh
                            string filePath = Path.Combine(folderPath, hinh);
                            FileUpload1.SaveAs(filePath);

                            hinh = (Path.Combine("image//products", masp, hinh)).Substring(7);

                            lbThongBao.Text = "folderPath=" + folderPath + " filePath=" + filePath;
                            kq = kn.capNhatDuLieu("Update SANPHAM Set HINH='" + hinh + "' Where MASANPHAM='" + premasp + "'");
                        }
                        catch //neu xay ra loi thi HINH se duoc giu nguyen
                        {
                        }
                    }

                    if (kq > 0)
                    {
                        Response.Redirect("ad_default.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Cập nhật không thành công";
                    }
                }
            }
            else
            {
                lbThongBao.Text = ("Nhập đủ thông tin cần thiết (*)");
            }
        }



        //



        protected void btnBack_Click(object sender, EventArgs e)
        {
            string sort = Request.QueryString["sort"];
            string sortitem = Request.QueryString["sortitem"];
            string search = Request.QueryString["search"];
            Response.Redirect("ad_default.aspx?search=" + search + "&sort=" + sort + "&sortitem=" + sortitem);
        }
    }
}