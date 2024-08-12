using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DoAn
{
    public partial class ad_usersmanage : System.Web.UI.Page
    {
        LopKetNoi kn = new LopKetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sort = Request.QueryString["sort"];
                string sortitem = Request.QueryString["sortitem"];
                string search = Request.QueryString["search"];
                string sql;


                if (string.IsNullOrEmpty(sort) && string.IsNullOrEmpty(search)) //lan dau truy cap
                {
                    rbtSort.Items[0].Selected = true;
                    sql = "Select * From NGUOIDUNG ORDER BY TENNGUOIDUNG";
                }
                else if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(search)) //vua tim kiem va sap xep
                {
                    tbSearch.Text = search;
                    if (!string.IsNullOrEmpty(sortitem))
                    {
                        int n_sortitem = int.Parse(sortitem);
                        rbtSort.Items[n_sortitem].Selected = true;
                    }
                    sql = "Select * From NGUOIDUNG Where TENNGUOIDUNG like '%" + search + "%' or DIACHI like N'%" + search + "%' ORDER BY " + sort;
                }
                else //neu co tim kiem hoac sap xep
                {
                    if (!string.IsNullOrEmpty(sort)) //neu co sap xep
                    {
                        if (!string.IsNullOrEmpty(sortitem))
                        {
                            int n_sortitem = int.Parse(sortitem);
                            rbtSort.Items[n_sortitem].Selected = true;
                        }
                        sql = "Select * From NGUOIDUNG ORDER BY " + sort;
                    }
                    else //neu co tim kiem
                    {
                        tbSearch.Text = search;
                        rbtSort.Items[0].Selected = true;

                        sql = "Select * From NGUOIDUNG Where TENNGUOIDUNG like '%" + search + "%' or DIACHI like N'%" + search + "%'";
                    }
                }

                GridView1.DataSource = kn.layDuLieu(sql);
                GridView1.DataBind();
            }
        }

        protected void btnBlock_Click(object sender, EventArgs e)
        {
            string mand = ((Button)sender).CommandArgument;

            string folderPath = Server.MapPath("~/image/users/" + mand);
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }

            kn.capNhatDuLieu("Delete From DONHANG Where MANGUOIDUNG='" + mand + "'");
            kn.capNhatDuLieu("Delete From NGUOIDUNG Where MANGUOIDUNG='" + mand + "'");
            Response.Redirect("ad_usersmanage.aspx");
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = rbtSort.SelectedValue;
            int sortitem = 0;
            if (selectedValue.Equals("TENNGUOIDUNG"))
            {
                sortitem = 0;
            }
            else if (selectedValue.Equals("DIACHI"))
            {
                sortitem = 1;
            }
            string search = Request.QueryString["search"];

            if (!string.IsNullOrEmpty(search))
            {
                Response.Redirect("ad_usersmanage.aspx?search=" + search + "&sort=" + selectedValue + "&sortitem=" + sortitem);
            }
            else
            {
                Response.Redirect("ad_usersmanage.aspx?sort=" + selectedValue + "&sortitem=" + sortitem);
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string search = tbSearch.Text;
            if (!string.IsNullOrEmpty(search))
            {
                Response.Redirect("ad_usersmanage.aspx?search=" + search);
            }
            else
            {
                Response.Redirect("ad_usersmanage.aspx?");
            }
        }
    }
}