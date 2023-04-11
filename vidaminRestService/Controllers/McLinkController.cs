using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Model;
using vidaminRestService.Service;

namespace vidaminRestService.Controllers
{
    [Route("api/McLinks")]
    [ApiController]
    public class McLinkController : Controller
    {
        private readonly NHibernate.ISession _session;

        public McLinkController(NHibernate.ISession session)
        {
            _session = session;
        }

        [HttpGet]
        public IList<links> Get()
        {
            try
            {
                return _session.QueryOver<links>().List();

            }
            catch (Exception e)
            {
                string s = e.Message;
                Console.WriteLine(s);
                return null;
            }
        }
    }
}
