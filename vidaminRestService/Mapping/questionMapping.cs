using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Model;

namespace vidaminRestService.Mapping
{
    public class questionMapping : ClassMap<question>
    {
        public questionMapping()
        {
            Id(x => x.id).Column("id");
            Map(x => x.soru).Column("soru");
            Map(x => x.insert_date).Column("insert_date");
            Map(x => x.ref_user).Column("ref_user");
        }

    }
}