using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Model
{
    public class answer
    {
        public virtual long id { get; set; }
        public virtual long ref_user { get; set; }
        public virtual long ref_question { get; set; }
        public virtual string cevap { get; set; }
        public virtual string insert_date { get; set; }
    }
}
