using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Core.Model
{
    public class EmployeeModel
    {
        /*
         * export interface IEmployee{
            id:number;
            fullName:string;
            email:string;
            phone?:string;
            skills: ISkill[];
        }
        export interface ISkill{
            skillName:string;
            expInYear:number;
            proficiency:string;
        }
         */
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IList<SkillModel> Skills { get; set; }
    }
}
