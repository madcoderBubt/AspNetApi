using SimpleWebApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWebApi.Core.Interfaces
{
    public interface IDonarRepository
    {
        public List<DonarModel> Donars { get; }
        public bool AddOrEdit(DonarModel model);
        public List<DonarModel> GetDonarsByBlood(string blood);
        public DonarModel GetDonar(int id);
        public bool Delete(int id);
        public bool SetArea(int id, string area);
        public bool SetLastDonationDate(int id, DateTime date);
    }
}
