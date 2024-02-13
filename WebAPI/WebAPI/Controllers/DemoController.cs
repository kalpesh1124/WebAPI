using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DemoController : ApiController
    {

        MvcDataEntities db = new MvcDataEntities();
        //public string Get()
        //{
        //    return "Hello Tattya Vinchu API..!!!";
        //}

        //public string Get(int id)
        //{
        //    return "Square = " + (id * id);
        //}

        //[HttpGet] //USer created methods
        //[Route("api/method")] // user created method url
        //public string GetMethod()
        //{
        //    return "Tattya Vinchu";
        //}

        //[HttpGet] //user created method
        //[Route("api/square/{id}")] // user created method url with parameters
        //public string Square(int id)
        //{
        //    return "Square = " + (id * id);
        //}
        
        [HttpGet] // database value get method
        [Route("api/Employee")]
        public List<Emp> GetEmployee()
        {
            List<Emp> emp = db.Emps.ToList();
            return emp;
        }

        [HttpPost]
        [Route("api/AddEmployee")]
        public string AddEmp(Emp e)
        {
            db.Emps.Add(e);
            db.SaveChanges();
            return "Employee Added Successfully!!!!";
        }

        [HttpGet]
        [Route("api/GetEmp/{id}")]
        public JsonResult<Emp> GetEmpById(int id)
        {
            Emp e = db.Emps.Find(id);
            return Json(e);
        }

        [HttpGet]
        [Route("api/DeleteEmp/{id}")]
        public string DeleteStudent(int id)
        {
            Emp e = db.Emps.Find(id);
            db.Emps.Remove(e);
            db.SaveChanges();
            return "Employee Deleted Successfully!!!!";
        }

        [HttpPost]
        [Route("api/UpdateEmp")]
        public string UpdateStudent(Emp e)
        {
            db.Entry<Emp>(e).State = EntityState.Modified;
            db.SaveChanges();
            return "Employee Updated Successfully!!!!";
        }
    }
}
