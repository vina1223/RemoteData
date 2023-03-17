using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.ActivityList
{
    public class ActivityRequestModel
    {
        public string Name { get; set; }
        public string DataTime { get; set; }
        public bool IsComplete { get; set; }
    }
}
