using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StudentSystemForInformationCRUD
{
    class DB_Access
    {
        SqlConnection conn = new SqlConnection("Data Source=SANSAAE-PC\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True");
        
        public void addstudent(string regNo, string Fname, string Lname, string phoneNo)
        {
            conn.Open();
            // SqlCommand newCmd = new SqlCommand("insert into Students values = 'Fname', 'Lname', 'phoneNo' where regNo=@par1",conn);
            
                SqlCommand newCmd = new SqlCommand("INSERT INTO Students ([RegNo], [Fname], [Lname], [Phone]) VALUES (@par1, @par2, @par3, @par4)", conn);
                newCmd.Parameters.AddRange(new[] {
                new SqlParameter("@par1", regNo),
                new SqlParameter("@par2", Fname),
                new SqlParameter("@par3", Lname),
                new SqlParameter("@par4", phoneNo)
            });
            
            newCmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet FillStudentGrid(string Query, string Table)
        {
            conn.Open();

            SqlCommand newCmd = conn.CreateCommand();
            newCmd.Connection = conn;
            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = Query;

            SqlDataAdapter da = new SqlDataAdapter(newCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, Table);
            
            conn.Close();
            return ds;
        }
    }
}
