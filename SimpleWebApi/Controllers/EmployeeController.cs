using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Core.Interfaces;
using SimpleWebApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return employeeRepository.Employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeModel Get(int id)
        {
            return employeeRepository.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public EmployeeModel Post([FromBody] EmployeeModel model)
        {
            return employeeRepository.CreateEmployee(model);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public EmployeeModel Put(int id, [FromBody] EmployeeModel model)
        {
            return employeeRepository.SaveEmployee(model, id);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return employeeRepository.DeleteEmployee(id);
        }
    }
}
