using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Model
{
    public class links
    {
        public virtual int id { get; set; }
        public virtual string link_address { get; set; }
        public virtual string link_def { get; set; }
        public virtual int order { get; set; }
        public virtual int status { get; set; }
    }
}
