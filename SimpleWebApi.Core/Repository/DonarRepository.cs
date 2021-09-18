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
    public class DonarRepository : IDonarRepository
    {
        private DbDonar dbDonar = new DbDonar();

        public List<DonarModel> Donars => dbDonar.GetAllDonars();

        public bool AddOrEdit(DonarModel model)
        {
            int result;
            if (model.Id == 0)
            {
                result = dbDonar.NewDonar(model);
            }
            else
            {
                result = dbDonar.EditDonar(model);
            }
            return (result > 0);
        }

        public bool Delete(int id)
        {
            return (dbDonar.DeleteDonar(id) > 0);
        }

        public DonarModel GetDonar(int id)
        {
            var data = dbDonar.GetDonar(id);
            return data;
        }

        public List<DonarModel> GetDonarsByBlood(string blood)
        {
            var list = dbDonar.GetAvailDonars(blood);
            return list;
        }

        public bool SetArea(int id, string area)
        {
            var result = dbDonar.SetArea(id, area);
            return (result > 0);
        }

        public bool SetLastDonationDate(int id, DateTime date)
        {
            return (dbDonar.SetLastDonation(id, date) > 0);
        }
    }
}
