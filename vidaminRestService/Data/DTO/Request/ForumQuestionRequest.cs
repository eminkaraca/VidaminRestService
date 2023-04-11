using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Data.DTO.Request
{
    public class ForumQuestionRequest
    {
        public long ref_user { get; set; }
        public string soru { get; set; }
        public string insert_date { get; set; }
    }
}
