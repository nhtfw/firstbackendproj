using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DoAn
{
    public class LopKetNoi
    {

        SqlConnection con;

        private void moKetNoi()
        {
            String sqlcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\odink\source\repos\DoAn\DoAn\App_Data\doan.mdf;Integrated Security=True";
            con = new SqlConnection(sqlcon);
            con.Open();
        }

        private void dongKetNoi()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataTable layDuLieu(String sql)
        {
            DataTable dt = new DataTable();
            try
            {
                moKetNoi();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            finally
            {
                dongKetNoi();
            }
            return dt;
        }


        //public ArrayList layTatCaBanGhiVaoArray(String sql)
       // {
        //    ArrayList recordsList = new ArrayList();    
        //    try
            //{
              //  moKetNoi();

              //  string sqlQuery = "SELECT * FROM YourTableName";

                // Tạo và thực thi Command
              //  SqlCommand command = new SqlCommand(sqlQuery, con);

                // Đọc dữ liệu từ SqlDataReader
               // using (SqlDataReader reader = command.ExecuteReader())
              //  {
                    // Duyệt qua các bản ghi và thêm vào ArrayList
                  //  while (reader.Read())
                   // {
                        // Đọc các trường dữ liệu từ mỗi bản ghi
                   //     string mand = (string)reader["MANGUOIDUNG"];
                   //     string tendn = (string)reader["TENDANGNHAP"];
                  //      string masp = (string)reader["masp"];

                        // Đọc các trường dữ liệu khác cần thiết...

                        // Tạo một đối tượng (hoặc bản ghi) từ dữ liệu đọc được
                  //      YourRecordType record = new YourRecordType(id, name /*, other fields... */);

                        // Thêm đối tượng vào ArrayList
               //         recordsList.Add(record);
              //      }
             //   }
           // }
           // catch
           // {

          // }
          //  finally
          //  {

          //  }
        //}

        public int capNhatDuLieu(string sql)
        {
            try
            {
                moKetNoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                dongKetNoi();
            }
        }

        public object layLeDuLieu(string sql)
        {
            try
            {
                moKetNoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteScalar(); //tra ve gia tri duy nhat, thuong la gia tri dau tien cua hang dau tien
                //tra ve object, co the ep kieu theo mong muon
            }
            catch
            {
                return 0;
            }
            finally
            {
                dongKetNoi();
            }
        }

    }
}