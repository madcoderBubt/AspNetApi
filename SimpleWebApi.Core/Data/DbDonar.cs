using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SimpleWebApi.Core.Model;

namespace SimpleWebApi.Core.Data
{
    class DbDonar
    {
        const string conStr = @"Data Source=(local)\sqlexpress;Initial Catalog=BloodDonationSystemDb;Integrated Security=True";

        public List<DonarModel> GetAllDonars()
        {
            List<DonarModel> model = new List<DonarModel>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("GetAllDonars",con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                da.Fill(data);

                model = data.Tables[0].AsEnumerable().Select(s => new DonarModel()
                {
                    Id = s.Field<int>("Id"),
                    FullName = s.Field<string>("FullName"),
                    Email = s.Field<string>("Email"),
                    ContactNo = s.Field<string>("ContactNo"),
                    BloodGroup = s.Field<string>("BloodGroup"),
                    LastDonation = s.Field<DateTime>("LastDonation"),
                    BirthDate = s.Field<DateTime>("BirthDate"),
                    Area = s.Field<string>("Area"),
                    Gender = s.Field<string>("Gender")
                }).ToList();
                return model;
            }
        }
        public List<DonarModel> GetAvailDonars(string blood)
        {
            List<DonarModel> model = new List<DonarModel>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("GetAvailDonars", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@blood", blood);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                da.Fill(data);

                model = data.Tables[0].AsEnumerable().Select(s => new DonarModel()
                {
                    Id = s.Field<int>("Id"),
                    FullName = s.Field<string>("FullName"),
                    Email = s.Field<string>("Email"),
                    ContactNo = s.Field<string>("ContactNo"),
                    BloodGroup = s.Field<string>("BloodGroup"),
                    LastDonation = s.Field<DateTime>("LastDonation"),
                    BirthDate = s.Field<DateTime>("BirthDate"),
                    Area = s.Field<string>("Area"),
                    Gender = s.Field<string>("Gender")
                }).ToList();
                return model;
            }
        }
        public DonarModel GetDonar(int id)
        {
            DonarModel donar = new DonarModel();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("GetDonar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                da.Fill(data);
                donar = data.Tables[0].AsEnumerable().Select(s => new DonarModel() {
                    Id = s.Field<int>("Id"),
                    FullName = s.Field<string>("FullName"),
                    Email = s.Field<string>("Email"),
                    ContactNo = s.Field<string>("ContactNo"),
                    BloodGroup = s.Field<string>("BloodGroup"),
                    LastDonation = s.Field<DateTime>("LastDonation"),
                    BirthDate = s.Field<DateTime>("BirthDate"),
                    Area = s.Field<string>("Area"),
                    Gender = s.Field<string>("Gender")
                }).SingleOrDefault();
            }
            return donar;
        }
        public int NewDonar(DonarModel model)
        {
            string procName = "CreateDonar";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", model.FullName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                cmd.Parameters.AddWithValue("@BloodGroup", model.BloodGroup);
                cmd.Parameters.AddWithValue("@LastDonation", model.LastDonation);
                cmd.Parameters.AddWithValue("@BirthDate", model.BirthDate);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Area", model.Area);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }
        public int EditDonar(DonarModel model)
        {
            string procName = "UpdateDonar";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", model.FullName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                cmd.Parameters.AddWithValue("@BloodGroup", model.BloodGroup);
                cmd.Parameters.AddWithValue("@LastDonation", model.LastDonation);
                cmd.Parameters.AddWithValue("@BirthDate", model.BirthDate);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Area", model.Area);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }
        public int SetArea(int id, string area)
        {
            string procName = "SetArea";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Area", area);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }
        public int SetLastDonation(int id, DateTime lastDonation)
        {
            string procName = "SetLastDonation";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@LastDonation", lastDonation);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }
        public int DeleteDonar(int id)
        {
            string procName = "DeleteDonar";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }
    }
}
