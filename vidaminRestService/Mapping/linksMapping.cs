using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Model;

namespace vidaminRestService.Mapping
{
    public class linksMapping : ClassMap<links>
    {
        public linksMapping()
        {
            Id(x => x.id).Column("id");
            Map(x => x.link_address).Column("link_address");
            Map(x => x.link_def).Column("link_def");
            Map(x => x.order).Column("order");
            Map(x => x.status).Column("status");
        }

    }
}