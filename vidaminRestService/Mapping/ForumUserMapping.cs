using FluentNHibernate.Mapping;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Model;

namespace vidaminRestService.Mapping
{
    public class ForumUserMapping : ClassMap<forumuser>
    {
        public ForumUserMapping()
        {
            Id(x => x.id).Column("id");
            Map(x => x.mail).Column("mail");
            Map(x => x.name).Column("name");
            Map(x => x.nick).Column("nick");
            Map(x => x.phone).Column("phone");
            Map(x => x.surname).Column("surname");
        }

    }
}
