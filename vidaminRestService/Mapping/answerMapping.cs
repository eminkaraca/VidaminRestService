using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Model;

namespace vidaminRestService.Mapping
{
    public class answerMapping : ClassMap<answer>
    {
        public answerMapping()
        {
            Id(x => x.id).Column("id");
            Map(x => x.cevap).Column("cevap");
            Map(x => x.insert_date).Column("insert_date");
            Map(x => x.ref_question).Column("ref_question");
            Map(x => x.ref_user).Column("ref_user");
        }

    }
}
