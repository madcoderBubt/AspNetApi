using SimpleWebApi.Core.Model;
using SimpleWebApi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Core.Data
{
    class DbEmployee
    {
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> model = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(DefaultValues.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                da.Fill(data);

                model = data.Tables[0].AsEnumerable().Select(s => new EmployeeModel()
                {
                    Id = s.Field<int>("Id"),
                    FullName = s.Field<string>("FullName"),
                    Email = s.Field<string>("Email"),
                    Phone = s.Field<string>("Phone"),
                    Skills = data.Tables[1].AsEnumerable()
                    .Where(f=>f.Field<int>("EmpId") == s.Field<int>("Id"))
                    .Select(f=> new SkillModel()
                    {
                        SkillName = f.Field<string>("SkillName"),
                        ExpInYear = f.Field<decimal>("ExpInYear"),
                        Proficiency = f.Field<string>("Proficiency")
                    }).ToList()
                }).ToList();
                return model;
            }
            //return null;
        }

        public EmployeeModel GetEmployee(int id)
        {
            EmployeeModel model = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(DefaultValues.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empId", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                da.Fill(data);

                model = data.Tables[0].AsEnumerable().Select(s => new EmployeeModel()
                {
                    Id = s.Field<int>("Id"),
                    FullName = s.Field<string>("FullName"),
                    Email = s.Field<string>("Email"),
                    Phone = s.Field<string>("Phone"),
                    Skills = data.Tables[1].AsEnumerable()
                    .Where(f => f.Field<int>("EmpId") == s.Field<int>("Id"))
                    .Select(f => new SkillModel()
                    {
                        SkillName = f.Field<string>("SkillName"),
                        ExpInYear = f.Field<decimal>("ExpInYear"),
                        Proficiency = f.Field<string>("Proficiency")
                    }).ToList()
                }).SingleOrDefault();
                return model;
            }
        }

        public EmployeeModel SetEmployee(EmployeeModel model, int id=0)
        {
            using (SqlConnection con = new SqlConnection(DefaultValues.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@FullName", model.FullName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.Add(new SqlParameter("@empId", SqlDbType.Int) { Direction = ParameterDirection.Output});

                DataTable skills = new DataTable();
                skills.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("SkillName", typeof(string)),
                    new DataColumn("ExpInYear", typeof(decimal)),
                    new DataColumn("Proficiency", typeof(string))
                });
                foreach (var item in model.Skills)
                {
                    skills.Rows.Add(item.SkillName, item.ExpInYear, item.Proficiency);
                }
                try
                {
                    con.Open();
                    cmd.ExecuteScalar();
                    int returnId = Convert.ToInt32(cmd.Parameters["@empId"].Value);
                    SqlCommand cmd2 = new SqlCommand("SetSkills", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@empId", returnId);
                    cmd2.Parameters.Add(new SqlParameter("@table", SqlDbType.Structured)
                    {
                        TypeName = "SkillTableType",
                        Value = skills
                    });
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    model.Id = returnId;
                }
                catch (Exception ex)
                {
                    throw new Exception("Server Error", ex.InnerException);
                }
                return model;
            }
        }

        public int DeleteEmployee(int id)
        {
            string procName = "DelEmployee";
            using (SqlConnection con = new SqlConnection(DefaultValues.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
            }
            return id;
        }

    }
}
