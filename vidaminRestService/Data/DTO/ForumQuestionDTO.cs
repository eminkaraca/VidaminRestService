using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Data.DTO
{
    public class ForumQuestionDTO
    {
        public long id { get; set; }
        public long ref_user { get; set; }
        public string soru { get; set; }
        public string insert_date { get; set; }
        public long adet { get; set; }
        public string nick { get; set; }
    }
}
