using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Drawing;

namespace DBconnTest.Models
{
    public class DBmanager
    {
        string conn_SQL_DB_Path = "Data source=desktop-75mha3a\\mssqlserver2019;Initial Catalog=test;user id=sa;password=12345678 ";
        public List<City> Getcity()
        {
            List<City> list = new List<City>();
            SqlConnection myconn = new SqlConnection(conn_SQL_DB_Path);
            //string strSQL = ("select * from region where re1=@region1 AND passwd=@region2");
            string strSQL = " SELECT DISTINCT re1, re2 FROM region";
            SqlCommand cmd = new SqlCommand(strSQL, myconn);
            //cmd.Parameters.Add("@region1",System.Data.SqlDbType.VarChar).Value=region1;
            //cmd.Parameters.Add("@region2",System.Data.SqlDbType.VarChar).Value=region2 ;
            cmd.Connection = myconn;
            myconn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                City region = new City();
                region.Regioncityid = reader["re1"].ToString();
                region.Regioncity = reader["re2"].ToString();
                list.Add(region);
            }
            myconn.Close();
            return list;
        }

        public List<Village> Getvillage(int id)
        {
            List<Village> list = new List<Village>();
            SqlConnection myconn = new SqlConnection(conn_SQL_DB_Path);
            string strSQL = "SELECT re3 FROM region WHERE re1 = @cityid";
            SqlCommand cmd = new SqlCommand(strSQL, myconn);
            cmd.Parameters.Add("@cityid", System.Data.SqlDbType.Int).Value=id;
            cmd.Connection=myconn;
            myconn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                Village village = new Village();
                village.Regionvillage = reader["re3"].ToString();
                list.Add(village);
            }
            myconn.Close();
            return list;
        }
    }


    public class City
    {
        public string Regioncityid { get; set; }
        public string Regioncity { get; set; }
    }
    public class Village
    {
        //public string Regioncityid { get; set; }
        public string Regionvillage { get; set; }

    }
    public class UserData
    {
        public string id { get; set; }
        public string sex { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phonenum { get; set; }
        public string city { get; set; }
        public string village { get; set; }
        public string address { get; set; }
        public UserData()
        {
            id = string.Empty;
            sex = string.Empty;
            account = string.Empty;
            password = string.Empty;
            email = string.Empty;
            phonenum = string.Empty;
            city = string.Empty;
            village = string.Empty;
            address = string.Empty;
        }

        public UserData(string _id, string _sex, string _account, string _password, string _address)
        {
            id = _id;
            sex = _sex;
            account = _account;
            password = _password;
            address = _address;
        }


        //public override string ToString()
        //{
        //    return $"學號:{id}, 姓名:{name}, 分數:{score}.";
        //}
    }
}

    
