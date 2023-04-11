using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Model
{
    public class question
    {
        public virtual long id { get; set; }
        public virtual long ref_user { get; set; }
        public virtual string soru { get; set; }
        public virtual string insert_date { get; set; }
    }
}
