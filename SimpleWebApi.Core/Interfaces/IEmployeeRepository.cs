using SimpleWebApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<EmployeeModel> Employees { get; }
        public EmployeeModel GetEmployee(int empId);
        public List<SkillModel> GetEmployeeSkills(int empId);
        public SkillModel GetSkill(int id);
        public EmployeeModel SaveEmployee(EmployeeModel model, int empId);
        public EmployeeModel CreateEmployee(EmployeeModel model);
        public int DeleteEmployee(int id);
    }
}
