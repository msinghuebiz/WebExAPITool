using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models
{
    public class BasePageModel
    {
        public WebExAllUsers LoggedInUser { get; set; }
        public WebExDemographicInfo LoggedInDemoUser { get; set; }

        public String Header { get; set; }
    }
}
