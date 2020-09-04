using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace AngStudentDB
{
    /// <summary>
    /// Summary description for StudWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StudWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetStudents()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From tblStudents", con);

                DataSet ds = new DataSet();
                da.Fill(ds, "Students");

                List<Students> studentList = new List<Students>();
                DataView stuDataView = new DataView(ds.Tables["Students"]);

                foreach (DataRowView stuDataRowView in stuDataView)
                {
                    Students students = new Students();
                    students.ID = Convert.ToInt32(stuDataRowView["ID"]);
                    students.Name = stuDataRowView["Name"].ToString();
                    students.Gender = stuDataRowView["Gender"].ToString();
                    students.TotalMarks = Convert.ToInt32(stuDataRowView["TotalMarks"]);
                    students.SubjectID = Convert.ToInt32(stuDataRowView["SubjectID"]);

                    studentList.Add(students);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(studentList));
            }
        }
    }
}
