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

        public bool DeleteUsers(string studentname)
        {
            bool status = false;
            try
            {
                 conn.Open();

                 SqlCommand newCmd = conn.CreateCommand();
                 newCmd.Connection = conn;
                 newCmd.CommandType = CommandType.Text;
                 newCmd.CommandText = "delete from Students where Fname = '" + studentname +"'";

                 /*SqlCommand newCmd = new SqlCommand("delete from Students where ([Fname]) = VALUES (@par1)", conn);
                 newCmd.Parameters.AddRange(new[] {
                new SqlParameter("@par1", studentname),
            }); */

                 newCmd.ExecuteNonQuery();
                 status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public DataTable FillStudentsList()
        {
            DataTable tb1 = new DataTable();
            tb1.Columns.Add("studentname", typeof(string));

            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            SqlCommand newCmd = conn.CreateCommand();
            newCmd.Connection = conn;
            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = "select * from Students";

            SqlDataReader rd = newCmd.ExecuteReader();

            while (rd.Read())
            {
                tb1.Rows.Add(rd["Fname"]);
            }
            conn.Close();
            return tb1;
        }

        public void update_students(string regNo, string Fname, string Lname, string phoneNo)
        {
            conn.Open();

            SqlCommand newCmd = new SqlCommand("UPDATE Students SET ([RegNo], [Fname], [Lname], [Phone]) VALUES (@par1, @par2, @par3, @par4)", conn);
            newCmd.Parameters.AddRange(new[] {
                new SqlParameter("@par1", regNo),
                new SqlParameter("@par2", Fname),
                new SqlParameter("@par3", Lname),
                new SqlParameter("@par4", phoneNo)
            });

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = newCmd;
            conn.Close();
        }

        public string ReturnStudentData(string Primary_key, string Table_Name, string RegNo, string Column)
        {
            string temp = "";
            conn.Open();

           /*SqlCommand newCmd = new SqlCommand("SELECT ([Columns]) FROM ([Students]) WHERE ([Primary]) = ([RegNo]) VALUES (@par1, @par2, @par3, @par4)", conn);
            newCmd.Parameters.AddRange(new[]{
                new SqlParameter("@par1", Column),
                new SqlParameter("@par2", Table_Name),
                new SqlParameter("@par3", Primary_key),
                new SqlParameter("@par4", RegNo)
            }); */
            
            SqlCommand newCmd = conn.CreateCommand();
            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = "SELECT" + Column + "FROM" + Table_Name + "WHERE" + Primary_key + "=" + RegNo + "";

            SqlDataReader dr = newCmd.ExecuteReader();
            
            while (dr.Read())
            {
                temp = dr[Column].ToString();
            }
            dr.Close();
            conn.Close();
            return temp;
        }

        public void addstudent(string regNo, string Fname, string Lname, string phoneNo)
        {
                conn.Open();
            // SqlCommand newCmd = new SqlCommand("insert into Students values 'Fname', 'Lname', 'phoneNo' where regNo=@par1",conn);
            
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
