using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrucks.model.ViewModels
{
   public class ContractorsViewModel
    {
        public int UserId { get; set; }
        public string ContractorFirstName { get; set; }

        public string ContractorLastName { get; set; }
        public int ContractorAge { get; set; }
        public int ContractorPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string State { get; set; }
        public string City { get; set; }



    }
}
