using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Model;

namespace vidaminRestService.Mapping
{
    public class handshakeMapping : ClassMap<handshake>
    {
        public handshakeMapping()
        {
            Id(x => x.id).Column("id");
            Map(x => x.app_name).Column("app_name");
            Map(x => x.link).Column("link");
            Map(x => x.message).Column("message");
            Map(x => x.status).Column("status");
        }

    }
}