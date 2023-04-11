using Microsoft.AspNetCore.Mvc;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidaminRestService.Data.DTO;
using vidaminRestService.Data.DTO.Request;
using vidaminRestService.Model;

namespace vidaminRestService.Controllers
{
    [Route("api/ForumAnswer")]
    [ApiController]
    public class ForumAnswerController : Controller
    {
        private readonly NHibernate.ISession _session;

        public ForumAnswerController(NHibernate.ISession session)
        {
            _session = session;
        }
        // POST: ForumQuestionController/Create
        [HttpPost]
        public answer Create(ForumAnswerRequest collection)
        {
            try
            {
                answer forumAnswer = new answer();

                forumAnswer.insert_date = collection.insert_date;
                forumAnswer.ref_user = collection.ref_user;
                forumAnswer.cevap = collection.answer;
                forumAnswer.ref_question = collection.ref_question;

                _session.Save(forumAnswer);

                return forumAnswer;
            }
            catch
            {
                return null;
            }
        }


        [HttpGet]
        public IList<ForumAnswerDTO> Get(int questionId)
        {
            try
            {
                var sql = @"SELECT c.cevap,c.insert_date,u.Nick as nick
                            FROM mc.answer c, mc.forumuser u
                            WHERE c.ref_user = u.id AND c.ref_question = " + questionId + @"
                            ORDER BY insert_date desc LIMIT 100";
                var query = _session.CreateSQLQuery(sql);
                var result = query.SetResultTransformer(Transformers.AliasToBean<ForumAnswerDTO>()).List<ForumAnswerDTO>();
                return (IList<ForumAnswerDTO>)result;

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
