using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc.Razor;
using WebAPICRUD.Models;

namespace WebAPICRUD.Controllers
{
    public class CRUDAPIController : ApiController
    {
        WebAPIEntities dbObj = new WebAPIEntities();

        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Employee> empList = dbObj.Employees.ToList();
            return Ok(empList);
        }

        [HttpPost]
        public IHttpActionResult addEmp(Employee e)
        {
            //To insert new emp record 
            dbObj.Employees.Add(e);
            //To save inserted record
            dbObj.SaveChanges();
            return Ok();
        }

    }
}
