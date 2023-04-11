using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vidaminRestService.Model
{
    [Route("api/McHandshake")]
    [ApiController]
    public class McHandshakeController : Controller
    {
        private readonly NHibernate.ISession _session;

        public McHandshakeController(NHibernate.ISession session)
        {
            _session = session;
        }

        [HttpGet]
        public IList<handshake> Get()
        {
            try
            {

                return _session.QueryOver<handshake>().List();

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
