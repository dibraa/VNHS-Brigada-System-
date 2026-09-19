using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BrigadaEskwela_SoftwareDevelopment_II
{
    class Global
    {

        // Server Connection

        public static string source = "192.168.1.10";
        public static string catalog = "01_BrigadaEskwelaDB";
        public static string user = "sa";
        public static string password = "jepoi2020";
        //END Server Connection

        // Server Driver
        SqlConnection con = new SqlConnection();
        SqlDataAdapter ds = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable DataTable = new DataTable();
        // END Server Driver 


        // Connection String
        //public static string Connection = @"Data Source='" + Global.source + "';Initial Catalog ='" + Global.catalog + "';User ID='" + Global.user + "';Password='" + Global.password + "';MultipleActiveResultSets=true;";
        public static string Connection = "Data Source=WIN-CORKVK3B0PQ\\SQLEXPRESS;Initial Catalog=01_BrigadaEskwelaDB;Integrated Security=True";
        //public static string Connection = @"Data Source = KOREANO-;Initial Catalog =01_BrigadaEskwelaDB;Integrated Security= True";

        //public static string Connection = @"Data Source=DESKTOP-7DOVRTE\SQLEXPRESS;Initial Catalog=01_BrigadaEskwelaDB;Integrated Security=True";

        //public static string Connection = "Data Source=WIN-CORKVK3B0PQ\\SQLEXPRESS;Initial Catalog=01_BrigadaEskwelaDB;Integrated Security=True";
       //public static string Connection = @"Data Source = STARRYSKY\SQLEXPRESS;Initial Catalog = 01_BrigadaEskwelaDB;Integrated Security = True";

        public static string Fname = "";
        public static string Mname = "";
        public static string Lname = "";
        public static string Username = "";
        public static string AccountType = "";
        public static string UserID = "";
        public static string YearFrom = "";
        public static string YearTo = "";

        public static string SchoolYearID = "";
        
        public void CountRecords()
        {

        }

        public void Adapt()
        {
            
        }


    }
}
