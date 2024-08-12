using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyMuaBanDienThoai
{
    class DBConnect_Khai
    {
        public string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUA_HANG_BAN_DIEN_THOAI;Persist Security Info=True;User ID=sa;Password=khai754123";
        SqlConnection conn;
        public DBConnect_Khai()
        {
            conn = new SqlConnection(chuoiketnoi);
        }
        public DBConnect_Khai(string chuoikn)
        {
            conn = new SqlConnection(chuoikn);
        }
        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public int getNonQuery(string chuoiTruyVan)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoiTruyVan, conn);
            int kq = cmd.ExecuteNonQuery();
            Close();
            return kq;
        }
        public int getScalar(string chuoiTruyVan)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoiTruyVan, conn);
            int kq = (int)cmd.ExecuteScalar();
            Close();
            return kq;
        }
        public SqlDataReader getDataReader(string sql)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        public DataTable getDaTaTable(string chuoitruyvan)
        {
            SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public int upDateDataTable(DataTable dtnew, string chuoitruyvan)
        {
            SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dtnew);
            return kq;
        }
        public int Kq(string sql)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = cmd.ExecuteNonQuery();
            Close();
            return kq;
        }
        public bool ktraMaDonHang(string ma)
        {
            Open();
            string ktra = "select count(*) from DONHANG where MADONHANG ='" + ma + "'";
            SqlCommand cmd = new SqlCommand(ktra, conn);
            int count = (int)cmd.ExecuteScalar();

            if (count == 1)
                return true;
            return false;
            Close();
        }
    }
}
