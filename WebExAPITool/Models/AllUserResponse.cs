using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExAPITool.Models
{
    public class AllUserResponse
    {
        public List<Tuple<string, string>> Properties { get; set; }

    }

    public class WebExAllUsers
    {
        public int IndexID { get; set; }
        public List<WebExSingleUser> LinkData { get; set; }
    }
}
