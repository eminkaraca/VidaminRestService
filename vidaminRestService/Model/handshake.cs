using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Model
{
    public class handshake
    {
        public virtual int id { get; set; }
        public virtual string link { get; set; }
        public virtual string message { get; set; }
        public virtual string app_name { get; set; }

        public virtual int status { get; set; }
    }
}
