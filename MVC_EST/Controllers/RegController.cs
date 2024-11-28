using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace MVC_EST.Controllers
{
    public class RegController : Controller {}

        // GET: Reg

namespace YourApp.Controllers
    {
        public class StudentController : Controller
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            
            // GET: Student Registration Form
            public ActionResult Register()
            {
                var model = new RegController
                {
                    Qualifications = new List<RegController> { new RegController() } 
                };
                return View(model);
            }

            // POST: Submit Student Registration Data
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Register(RegController model)
            {
                if (ModelState.IsValid)
                {
                    // Database connection string
                    string connectionString = "YourConnectionStringHere";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // 1. Insert student data using stored procedure
                        SqlCommand cmdInsertStudent = new SqlCommand("InsertStudent", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmdInsertStudent.Parameters.AddWithValue("@FirstName", model.FirstName);
                        cmdInsertStudent.Parameters.AddWithValue("@LastName", model.LastName);
                        cmdInsertStudent.Parameters.AddWithValue("@Age", model.Age);
                        cmdInsertStudent.Parameters.AddWithValue("@DOB", model.DOB);
                        cmdInsertStudent.Parameters.AddWithValue("@Gender", model.Gender);
                        cmdInsertStudent.Parameters.AddWithValue("@Email", model.Email);
                        cmdInsertStudent.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                        cmdInsertStudent.Parameters.AddWithValue("@Username", model.Username);
                        cmdInsertStudent.Parameters.AddWithValue("@Password", model.Password);

                        cmdInsertStudent.ExecuteNonQuery();

                        // 2. Get the StudentId after insertion
                        SqlCommand cmdGetStudentId = new SqlCommand("SELECT SCOPE_IDENTITY()", conn);
                        int studentId = Convert.ToInt32(cmdGetStudentId.ExecuteScalar());

                        // 3. Insert qualification data using stored procedure
                        foreach (var qualification in model.Qualifications)
                        {
                            SqlCommand cmdInsertQualification = new SqlCommand("InsertQualification", conn)
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            cmdInsertQualification.Parameters.AddWithValue("@StudentId", studentId);
                            cmdInsertQualification.Parameters.AddWithValue("@CourseName", qualification.CourseName);
                            cmdInsertQualification.Parameters.AddWithValue("@Percentage", qualification.Percentage);
                            cmdInsertQualification.Parameters.AddWithValue("@YearOfPassing", qualification.YearOfPassing);

                            cmdInsertQualification.ExecuteNonQuery();
                        }
                    }

                    
                    return RedirectToAction("Confirmation");
                }

               
                return View(model);
            }

            
            public ActionResult Confirmation()
            {
                return View();
            }
        }
    }
}
