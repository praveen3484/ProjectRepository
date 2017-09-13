using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrucks.model.ViewModels
{
   public class TransportexpenditureViewModel
    {
        //NEW JOB POSTS
        public string JobTitle { get; set; }
        public int LoadWeight { get; set; }

      

        public string LoadType { get; set; }
        public string TruckType { get; set; }
        //JOB APPLICATION
        public long AskingPrice { get; set; }
    }
}
