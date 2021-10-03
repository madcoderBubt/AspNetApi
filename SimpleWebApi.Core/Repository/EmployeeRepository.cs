using SimpleWebApi.Core.Data;
using SimpleWebApi.Core.Interfaces;
using SimpleWebApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        DbEmployee dbEmployee = new DbEmployee();
        public List<EmployeeModel> Employees => dbEmployee.GetEmployees();

        public EmployeeModel CreateEmployee(EmployeeModel model)
        {
            return dbEmployee.SetEmployee(model, 0);
        }

        public int DeleteEmployee(int id)
        {
            return dbEmployee.DeleteEmployee(id);
        }

        public EmployeeModel GetEmployee(int empId)
        {
            return dbEmployee.GetEmployee(empId);
        }

        public List<SkillModel> GetEmployeeSkills(int empId)
        {
            return null;
        }

        public SkillModel GetSkill(int id)
        {
            return null;
        }

        public EmployeeModel SaveEmployee(EmployeeModel model, int empId)
        {
            return dbEmployee.SetEmployee(model, empId);
        }
    }
}
