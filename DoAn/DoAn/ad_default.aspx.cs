using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace DoAn
{
    public partial class ad_default : System.Web.UI.Page
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
                    sql = "Select * From SANPHAM ORDER BY TENSANPHAM";
                }
                else if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(search)) //vua tim kiem va sap xep
                {
                    tbSearch.Text = search;
                    if (!string.IsNullOrEmpty(sortitem))
                    {
                        int n_sortitem = int.Parse(sortitem);
                        rbtSort.Items[n_sortitem].Selected = true;
                    }
                    sql = "Select * From SANPHAM Where MADANHMUC like '%" + search + "%' or TENSANPHAM like '%" + search + "%' ORDER BY " + sort;
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
                        sql = "Select * From SANPHAM ORDER BY " + sort;
                    }
                    else //neu co tim kiem
                    {
                        tbSearch.Text = search;
                        rbtSort.Items[0].Selected = true;

                        sql = "Select * From SANPHAM Where MADANHMUC like '%" + search + "%' or TENSANPHAM like '%" + search + "%'";
                    }
                }

                GridView1.DataSource = kn.layDuLieu(sql);
                GridView1.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string masp = ((Button)sender).CommandArgument;

            string sort = Request.QueryString["sort"];
            string sortitem = Request.QueryString["sortitem"];
            string search = Request.QueryString["search"];
            Response.Redirect("ad_editdevice.aspx?masp=" + masp + "&search=" + search + "&sort=" + sort + "&sortitem=" + sortitem);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string masp = ((Button)sender).CommandArgument;

            //xoa folder
            string folderPath = Server.MapPath("~/image/products/" + masp);
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }

            kn.capNhatDuLieu("Delete From SANPHAM Where MASANPHAM='" + masp + "'");

            string sort = Request.QueryString["sort"];
            string sortitem = Request.QueryString["sortitem"];
            string search = Request.QueryString["search"];
            Response.Redirect("ad_default.aspx?search=" + search + "&sort=" + sort + "&sortitem=" + sortitem);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = rbtSort.SelectedValue;
            int sortitem = 0;
            if (selectedValue.Equals("DONGIA ASC"))
            {
                sortitem = 1;
            }
            else if (selectedValue.Equals("DONGIA DESC"))
            {
                sortitem = 2;
            }
            else if (selectedValue.Equals("MADANHMUC"))
            {
                sortitem = 3;
            }
            else if (selectedValue.Equals("TENSANPHAM"))
            {
                sortitem = 0;
            }
            string search = Request.QueryString["search"];

            if (!string.IsNullOrEmpty(search))
            {
                Response.Redirect("ad_default.aspx?search=" + search + "&sort=" + selectedValue + "&sortitem=" + sortitem);
            }
            else
            {
                Response.Redirect("ad_default.aspx?sort=" + selectedValue + "&sortitem=" + sortitem);
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string search = tbSearch.Text;
            if (!string.IsNullOrEmpty(search))
            {
                Response.Redirect("ad_default.aspx?search=" + search);
            }
            else
            {
                Response.Redirect("ad_default.aspx?");
            }
        }
    }
}