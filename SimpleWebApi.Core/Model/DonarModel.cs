using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Core.Model
{
    public class DonarModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string BloodGroup { get; set; }
        public DateTime LastDonation { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Area { get; set; }
    }
}
