using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Data.DTO.Request
{
    public class ForumAnswerRequest
    {
        public long ref_user { get; set; }
        public long ref_question { get; set; }
        public string answer { get; set; }
        public string insert_date { get; set; }
    }
}
