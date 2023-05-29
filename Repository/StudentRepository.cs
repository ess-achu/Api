using ApiStudent.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiStudent.Repository
{
    public class StudentRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        public List<StudentModel> Get()
        {
            List<StudentModel> studentsDetails = new List<StudentModel>();
            SqlCommand com = new SqlCommand("GetAllStudents", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentsDetails.Add(
                    new StudentModel()
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["name"]),
                        age = Convert.ToInt32(dr["age"]),
                        grade = Convert.ToInt32(dr["class"]),
                    });
            }


            return studentsDetails;
        }

        public bool Put(int id, string name)
        {
            SqlCommand com = new SqlCommand("UpdateStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@name", name);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();


            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}