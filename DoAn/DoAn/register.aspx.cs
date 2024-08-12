using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DoAn
{
    public partial class register : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangKi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNewUserNameLogin.Text) && !string.IsNullOrEmpty(tbNewUserName.Text) && !string.IsNullOrEmpty(tbNewPassword.Text)
                && !string.IsNullOrEmpty(tbNewPhonenumber.Text) && !string.IsNullOrEmpty(tbNewLocation.Text))
            {
                string tendn = tbNewUserNameLogin.Text;
                string matkhau = tbNewPassword.Text;
                string tennd = tbNewUserName.Text;
                string sdt = tbNewPhonenumber.Text;
                string diachi = tbNewLocation.Text;
                string hinh = FileUpload1.FileName;

                if (matkhau.Length < 7 || tendn.Length < 9)
                {
                    lbThongBao.Text = "Nhập đủ và đúng thông tin";
                }
                else
                {
                    string mand = "user_" + tendn;

                    string checktendn = (string)kn.layLeDuLieu("Select TENDANGNHAP From NGUOIDUNG Where TENDANGNHAP='" + tendn + "'");

                    if (string.IsNullOrEmpty(checktendn)) //check trung ten dn
                    {
                        if (!string.IsNullOrEmpty(hinh))//neu nguoi dung input anh
                        {
                            try
                            {
                                //tao folder
                                string folderPath = Server.MapPath("~/image/users/" + mand);
                                Directory.CreateDirectory(folderPath);

                                //luu anh
                                string filePath = Path.Combine(folderPath, hinh);
                                FileUpload1.SaveAs(filePath);

                                // lay path cua img vua tao
                                hinh = (Path.Combine("image//users", mand, hinh)).Substring(7);
                            }
                            catch
                            {
                                hinh = "user.png";
                            }
                        }
                        else
                        {
                            hinh = "user.png";
                        }

                        kn.capNhatDuLieu("Insert Into NGUOIDUNG (MANGUOIDUNG, TENDANGNHAP, MATKHAU, TENNGUOIDUNG, SODIENTHOAI, DIACHI, HINH)" +
                        "Values('" + mand + "', '" + tendn + "', '" + matkhau + "', N'" + tennd + "', '" + sdt + "', N'" + diachi + "', '"+hinh+"')");
                        lbThongBao.Text = "Đăng ký thành công";
                        //lbThongBao.Text = hinh;
                    }
                    else
                    {
                        lbThongBao.Text = "Tên đăng nhập đã có người sử dụng";
                    }
                }
            }
            else
            {
                lbThongBao.Text = "Nhập đủ và đúng thông tin";
            }
        }
    }
}