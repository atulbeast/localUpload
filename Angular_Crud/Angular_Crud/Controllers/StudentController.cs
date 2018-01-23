using Angular_Crud.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Web;

using System.Web.Mvc;


namespace Angular_Crud.Controllers
{
    public class StudentController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// this method is get list of employee and return json
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStudentList(StudentSearch ss)
        {
            //var StudentList = db.Students.Where(a => a.IsActive == true || a.IsActive == null).ToList();
            //return Json(StudentList, JsonRequestBehavior.AllowGet);

            using (var db = new StudentContext())
            {
                db.Database.Initialize(force: false);
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "Student_Listing";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ss.ID));
                cmd.Parameters.Add(new SqlParameter("@FirstName", ss.FirstName));
                cmd.Parameters.Add(new SqlParameter("@PageSize", ss.PageSize));
                cmd.Parameters.Add(new SqlParameter("@CurrentPage",ss.CurrentPage));
                db.Database.Connection.Open();
                var reader = cmd.ExecuteReader();
                List<StudentModel> StudentList = new List<StudentModel>();
                StudentList = ((IObjectContextAdapter)db).ObjectContext.Translate<StudentModel>(reader).ToList();
                reader.NextResult();
                TotalRecord tr = new TotalRecord();
                tr = ((IObjectContextAdapter)db).ObjectContext.Translate<TotalRecord>(reader).Single();
                MainDataSet mds = new MainDataSet();
                mds.StudentModelList = StudentList;
                mds.TotalRec = tr;
                return Json(mds, JsonRequestBehavior.AllowGet);
            }   
        }

       

        public JsonResult GetStates()
        {
            List<State> allState = new List<State>();
            using (StudentContext sc = new StudentContext())
            {
                allState = sc.States.OrderBy(a => a.SName).ToList();
            }
            return new JsonResult { Data = allState, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetCitys()
        {
            List<City> CityList = new List<City>();
            using (StudentContext ct = new StudentContext())
            {
                CityList = ct.Citys.OrderBy(a => a.Name).ToList();
            }
            return new JsonResult { Data = CityList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpPost]
        public string Post()
        {
            try
            {
                HttpPostedFileBase file = Request.Files["file"];
              string virtualpathImg = Guid.NewGuid().ToString() +Path.GetFileName(file.FileName);
                var path = Path.Combine(
                     
                       System.Web.Hosting.HostingEnvironment.MapPath("~/Uploaded Pic"),
                       virtualpathImg
                   );
                file.SaveAs(path);
              
                return "Uploaded Pic/" + virtualpathImg;

               
            }
            catch (Exception)
            {
                return null;
            }
        }



        [HttpPost]
        public int AddStudent(Student st)
        {
            try
            {
                //if (st != null)
                //{
                //    st.IsActive = true;
                //}
                //var addNew = db.Students.Add(st);
                //db.SaveChanges();
                //var id = st.Id;
                //return 1;

                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }
                db.Database.Initialize(force: false);
                db.Database.Connection.Open();
                DbCommand _dbCmd = db.Database.Connection.CreateCommand();
                _dbCmd.CommandText = "Student_Insert";
                _dbCmd.CommandType = CommandType.StoredProcedure;
                _dbCmd.Parameters.AddRange(new SqlParameter[] {
                     new SqlParameter("@FirstName", st.FirstName),
                     new SqlParameter("@LASTNAME",st.LastName),
                     new SqlParameter("@ADDRESS ",st.Address),
                     new SqlParameter("@IsActive",true),
                     new SqlParameter("@Country",st.Country),
                    new SqlParameter("@City",st.City),
                      new SqlParameter("@State",st.State),
                      new SqlParameter("@Email",st.Email),
                     new SqlParameter("@PhnNo",st.PhnNo),
                     new SqlParameter("@DOB",st.DOB),
                     new SqlParameter("@Gender",st.Gender),
                      new SqlParameter("@Btech",st.Btech),
                      new SqlParameter("@Bsc",st.Bsc),
                      new SqlParameter("@Bca",st.Bca),
                      new SqlParameter("@Ba",st.Ba),
                        new SqlParameter("@LogoUrl",st.LogoUrl)
                    });
                object result = _dbCmd.ExecuteScalar();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        
    

        public int DeleteStudent(int Id)
        {
           //Student stuobj = new Student();
           // try
           // {
           //     stuobj = db.Students.Find(Id);
           //     stuobj.IsActive = false;
           //     db.SaveChanges();
           //     return 1;
           // }
           // catch (Exception ex)
           // {
           //     return 0;
           // }

            if (db.Database.Connection.State == ConnectionState.Open)
            {
                db.Database.Connection.Close();
            }
            db.Database.Initialize(force: false);
            db.Database.Connection.Open();
            DbCommand _dbCmd = db.Database.Connection.CreateCommand();
            _dbCmd.CommandText = "Student_Delete";
            _dbCmd.CommandType = CommandType.StoredProcedure;
            _dbCmd.Parameters.AddRange(new SqlParameter[] {
             new SqlParameter("@ID", Id),
            });
            object result = _dbCmd.ExecuteScalar();
            return 1;
        }

        [HttpPost]
        public int  UpdateStudent(Student st)
        {
            try
            {
                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }
                db.Database.Initialize(force: false);
                db.Database.Connection.Open();
                DbCommand _dbCmd = db.Database.Connection.CreateCommand();
                _dbCmd.CommandText = "Student_Update";
                _dbCmd.CommandType = CommandType.StoredProcedure;
                _dbCmd.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@ID", st.Id),
                     new SqlParameter("@FirstName", st.FirstName),
                     new SqlParameter("@LASTNAME",st.LastName),
                     new SqlParameter("@ADDRESS ",st.Address),
                     new SqlParameter("@IsActive",true),
                     new SqlParameter("@City",st.City),
                      new SqlParameter("@State",st.State),
                      new SqlParameter("@Email",st.Email),
                     new SqlParameter("@PhnNo",st.PhnNo),
                     new SqlParameter("@DOB",st.DOB),
                     new SqlParameter("@Gender",st.Gender),
                      new SqlParameter("@Btech",st.Btech),
                      new SqlParameter("@Bsc",st.Bsc),
                      new SqlParameter("@Bca",st.Bca),
                      new SqlParameter("@Ba",st.Ba),
                    });
                object result = _dbCmd.ExecuteScalar();
               //db.Entry(st).State = EntityState.Modified;
               //db.SaveChanges();

            return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}