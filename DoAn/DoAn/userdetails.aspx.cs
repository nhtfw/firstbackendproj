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
    public partial class userdetails2 : System.Web.UI.Page
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
                        dlUserInformation.DataSource = dt;
                        dlUserInformation.DataBind();

                        // dlOrded.DataSource = kn.layDuLieu("Select * from DONHANG,SANPHAM Where TENDANGNHAP='" + tendn + "' and TRANGTHAI='mua_hang'" +
                        //  " and DONHANG.MASANPHAM = SANPHAM.MASANPHAM");
                        //  dlOrded.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void lbusername_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            DataListItem item = (DataListItem)tb.Parent;
            TextBox lbusername = (TextBox)item.FindControl("lbusername");

            string tennd = lbusername.Text;

            if (string.IsNullOrEmpty(tennd))
            {
                Response.Redirect("userdetails.aspx");
            }

        }

        protected void lbphonenumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            DataListItem item = (DataListItem)tb.Parent;
            TextBox lbphonenumber = (TextBox)item.FindControl("lbphonenumber");

            string sdt = lbphonenumber.Text;

            if (string.IsNullOrEmpty(sdt))
            {
                Response.Redirect("userdetails.aspx");
            }
        }

        protected void lblocation_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            DataListItem item = (DataListItem)tb.Parent;
            TextBox lblocation = (TextBox)item.FindControl("lblocation");

            string diachi = lblocation.Text;

            if (string.IsNullOrEmpty(diachi))
            {
                Response.Redirect("userdetails.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ContentPlaceHolder cph = (ContentPlaceHolder)btn.NamingContainer;

            TextBox lbusername = new TextBox();
            TextBox lbphonenumber = new TextBox();
            TextBox lblocation = new TextBox();
            TextBox tbPass = new TextBox();

            FileUpload FileUpload1 = new FileUpload();
            Label lbID = new Label();

            foreach (DataListItem item in dlUserInformation.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    // Tìm điều khiển bên trong DataList
                    lbusername = (TextBox)item.FindControl("lbusername");
                    lbphonenumber = (TextBox)item.FindControl("lbphonenumber");
                    lblocation = (TextBox)item.FindControl("lblocation");
                    tbPass = (TextBox)item.FindControl("tbPass");

                    FileUpload1 = (FileUpload)item.FindControl("FileUpload1");
                    lbID = (Label)item.FindControl("lbID");
                }
            }



            if (string.IsNullOrEmpty(tbPass.Text))
            {
                lbThongbao.Text = "Yêu cầu nhập mật khẩu";
            }
            else
            {
                string pass = tbPass.Text;
                string truepass = (string)kn.layLeDuLieu("Select MATKHAU From NGUOIDUNG Where TENDANGNHAP='" + Session["loginname"] + "'");
                if (pass.Equals(truepass))
                {
                    int kq;
                    string new_username = lbusername.Text;
                    string new_phonenumber = lbphonenumber.Text;
                    string new_location = lblocation.Text;

                    string hinh = FileUpload1.FileName;
                    string mand = lbID.Text;

                    if (!string.IsNullOrEmpty(hinh))//neu nguoi dung input anh
                    {
                        try
                        {
                            //kiem tra su ton tai cua folder
                            string folderPath = Server.MapPath("~/image/users/" + mand);
                            if (Directory.Exists(folderPath))
                            {
                                //xoa folder da co truoc do
                                Directory.Delete(folderPath, true);
                            }

                            //tao folder
                            Directory.CreateDirectory(folderPath);

                            //luu anh
                            string filePath = Path.Combine(folderPath, hinh);
                            FileUpload1.SaveAs(filePath);

                            // lay path cua img vua tao
                            hinh = (Path.Combine("image//users", mand, hinh)).Substring(7);

                            kn.capNhatDuLieu("Update NGUOIDUNG Set HINH='" + hinh + "' Where MANGUOIDUNG='" + mand + "'");
                        }
                        catch
                        {
                        }
                    }

                    kq = kn.capNhatDuLieu("Update NGUOIDUNG Set TENNGUOIDUNG= N'" + new_username + "', DIACHI= N'" + new_location + "', SODIENTHOAI='" + new_phonenumber +
                        "' Where TENDANGNHAP='" + Session["loginname"] + "'");
                    if (kq > 0)
                    {
                        Response.Redirect("userdetails.aspx");
                    }
                }
                else
                {
                    lbThongbao.Text = "Nhập sai mật khẩu";
                }
            }

        }
    }
}