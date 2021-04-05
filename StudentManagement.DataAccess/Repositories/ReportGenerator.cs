using StudentManagement.Api.Entities;
using StudentManagement.DataAccess.Repositories.Interfaces;
using StudentManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Repositories
{
    public class ReportGenerator : IReportGeneratorRepository
    {
        public List<CourseWithSpace> GetCourseWithSpaces()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["StudentDbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("sp_CourseWithSpace", con);
                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                List<CourseWithSpace> coursewithspace = new List<CourseWithSpace>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CourseWithSpace cs = new CourseWithSpace();
                        cs.CourseId = Convert.ToInt32(reader[0]);
                        cs.CourseCode = Convert.ToString(reader[1]) ?? String.Empty;
                        cs.CourseName = Convert.ToString(reader[2]) ?? String.Empty;
                        cs.Space = Convert.ToInt32(reader[3]);
                        cs.TotalRegisteredStudents = Convert.ToInt32(reader[4]);
                        coursewithspace.Add(cs);
                    }
                }
                return coursewithspace;
            }             
        }

        public List<RegisteredCourseStudent> RegisteredCourseForStudent()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["StudentDbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("sp_RegisteredCourseForStudent", con);
                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                List<RegisteredCourseStudent> regstudent = new List<RegisteredCourseStudent>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RegisteredCourseStudent cs = new RegisteredCourseStudent();
                        cs.StudentId = Convert.ToInt32(reader[0]);
                        cs.FirstName = Convert.ToString(reader[1]) ?? String.Empty;
                        cs.SurName = Convert.ToString(reader[2]) ?? String.Empty;
                        cs.NoOfRegisteredCourses = Convert.ToInt32(reader[3]);
                        regstudent.Add(cs);
                    }
                }
                return regstudent;
            }
        }

        public List<StudentListForCourse> StudentListForCourse()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["StudentDbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("sp_StudentListforCourse", con);
                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                List<StudentListForCourse> regstudent = new List<StudentListForCourse>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentListForCourse cs = new StudentListForCourse();
                        cs.CourseCode = Convert.ToString(reader[0]) ?? String.Empty;
                        cs.CourseName = Convert.ToString(reader[1]) ?? String.Empty;
                        cs.FirstName = Convert.ToString(reader[2]) ?? String.Empty;
                        cs.SurName = Convert.ToString(reader[3]) ?? String.Empty;
                        regstudent.Add(cs);
                    }
                }
                return regstudent;
            }
        }

        public List<StudentNotRegisteredForMaxCourse> StudentNotRegisteredForMaxCourse()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["StudentDbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("sp_StudentNotRegisteredForMaxCourse", con);
                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                List<StudentNotRegisteredForMaxCourse> regstudent = new List<StudentNotRegisteredForMaxCourse>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentNotRegisteredForMaxCourse cs = new StudentNotRegisteredForMaxCourse();
                        cs.StudentId = Convert.ToInt32(reader[0]) ;
                        cs.FirstName = Convert.ToString(reader[1]) ?? String.Empty;
                        cs.CoursesEnrolled = Convert.ToInt32(reader[2]);
                        regstudent.Add(cs);
                    }
                }
                return regstudent;
            }
        }









    }
}
