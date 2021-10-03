using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Core.Shared
{
    static class DefaultValues
    {
        private static string myVar = @"Data Source=(local)\sqlexpress;Initial Catalog=BloodDonationSystemDb;Integrated Security=True";

        public static string ConnectionString
        {
            get { return myVar; }
        }
    }
}
