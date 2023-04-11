using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Data.DTO;
using vidaminRestService.DBContexts;
using vidaminRestService.Model;

namespace vidaminRestService.Controllers
{
    [Route("api/McUser")]
    [ApiController]
    public class McUserController : Controller
    {
        private readonly NHibernate.ISession _session;

        public McUserController(NHibernate.ISession session)
        {
            _session = session;
        }


        [HttpGet]
        public forumuser Get()
        {
            try
            {
                int userCount = _session.QueryOver<forumuser>().List().Count;

                forumuser newUser = new forumuser();
                newUser.nick = "Guest_" + (userCount + 1);
               // newUser.id = userCount + 1;
                _session.Save(newUser);

                return newUser;

            }
            catch (Exception e) {
                string d = e.Message;
            }
            return null;
        }
        
        [HttpPut]
        public forumuser Create(UserDTO userDTO)
        {
            try
            {
                forumuser user = _session.QueryOver<forumuser>().Where(x => x.nick == userDTO.nick).SingleOrDefault();
                if (user != null)
                    throw new Exception("Nick exist");

                forumuser forumUser = new forumuser();
                forumUser.surname = userDTO.surname;
                forumUser.phone = userDTO.phone;
                forumUser.nick = userDTO.nick;
                forumUser.name = userDTO.name;
                forumUser.mail = userDTO.mail;

                _session.Save(forumUser);

                return forumUser;

            }
            catch (Exception e)
            {
                string d = e.Message;
            }
            return null;
        }
        
        [HttpPost]
        public forumuser Set(UserDTO userDTO)
        {
            try
            {
                forumuser forumUser = _session.QueryOver<forumuser>().Where(x => x.nick == userDTO.nick).SingleOrDefault();

                if (forumUser == null)
                    throw new Exception("no such user");
                forumUser.surname = userDTO.surname;
                forumUser.phone = userDTO.phone;
                forumUser.nick = userDTO.nick;
                forumUser.name = userDTO.name;
                forumUser.mail = userDTO.mail;

                _session.Update(forumUser);

                return forumUser;

            }
            catch (Exception e)
            {
                string d = e.Message;
            }
            return null;
        }

    }
}
