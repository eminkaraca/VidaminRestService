using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Data.DTO;
using vidaminRestService.Data.DTO.Request;
using vidaminRestService.Model;

namespace vidaminRestService.Controllers
{
    [Route("api/ForumQuestion")]
    [ApiController]
    public class ForumQuestionController : Controller
    {
        private readonly NHibernate.ISession _session;

        public ForumQuestionController(NHibernate.ISession session)
        {
            using (StreamWriter writer = new StreamWriter("log.txt"))
            {
                writer.WriteLine("ForumQuestionController");
              
            }
            // Read a file  
           
            _session = session;
        }
        // POST: ForumQuestionController/Create
        [HttpPost]
        public question Create(ForumQuestionRequest collection)
        {
            try
            {
                question forumQuestion = new question();

                forumQuestion.insert_date = collection.insert_date;
                forumQuestion.ref_user = collection.ref_user;
                forumQuestion.soru = collection.soru;

                _session.Save(forumQuestion);
                return forumQuestion;
            }
            catch
            {
                return null;
            }
        }


        [HttpGet]
        public IList<ForumQuestionDTO> Get()
        {
            try
            {

                var sql = @"SELECT c.*, (SELECT COUNT(*) FROM mc.answer WHERE ref_question = c.id) as adet ,u.Nick as nick
                            FROM mc.question c, mc.forumuser u
                            WHERE c.ref_user = u.id
                            ORDER BY insert_date desc LIMIT 100";
                var query = _session.CreateSQLQuery(sql);
                var result = query.SetResultTransformer(Transformers.AliasToBean<ForumQuestionDTO>()).List<ForumQuestionDTO>();
                return (IList<ForumQuestionDTO>)result;

            }
            catch(Exception e)
            {
                string s = e.Message;
                using (StreamWriter writer = new StreamWriter("log.txt"))
                {
                    writer.WriteLine(s);

                }
                
                Console.WriteLine(s);
                return null;
            }
        }

       
    }
}
