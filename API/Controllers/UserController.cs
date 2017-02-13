using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi1.Models;

namespace TestApi1.Controllers
{
    public class UserController : ApiController
    {

        users _users = users.Instance();

        // GET api/<controller>
        public IEnumerable<UserInfo> Get()
        {
            return _users.List;
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]UserInfo _user)
        {
            if (_user != null)
            {
                _users.Add(_user);
               return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            }
            else
            {
               return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(string UserCode, [FromBody]UserInfo _user)
        {
            if (string.IsNullOrEmpty(UserCode))
            {
              return  new HttpResponseMessage() { StatusCode = HttpStatusCode.NotModified };
            }
            else
            {
                _users.Update(UserCode, _user);
              return  new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(string UserCode)
        {
            if (string.IsNullOrEmpty(UserCode))
            {
              return  new HttpResponseMessage() { StatusCode = HttpStatusCode.NotModified };
            }
            else
            {
                _users.Delete(UserCode);
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            }
        }
    }
}