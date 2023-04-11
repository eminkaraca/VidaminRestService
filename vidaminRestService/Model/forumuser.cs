using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Model
{
    public class forumuser
    {
        public virtual int id { get; set; }
        public virtual string mail { get; set; }
        public virtual string nick { get; set; }
        public virtual string name { get; set; }
        public virtual string surname { get; set; }
        public virtual string phone { get; set; }
    }
}
