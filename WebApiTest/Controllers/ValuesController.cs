using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTest.Business;
using WebApiTest.Data;
using WebApiTest.Entities;

namespace WebApiTest.Controllers
{
    public class ValuesController : ApiController
    {
        EmployeeBusinessLogic bl = new EmployeeBL();

        // GET api/values
        public IEnumerable<Employee> Get(int id)
        {
            return bl.GetEmployeeById(id);
        }

        // GET api/values/5
        public IEnumerable<Employee> GetEmployeesList()
        {
            return bl.GetEmployeeList();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
