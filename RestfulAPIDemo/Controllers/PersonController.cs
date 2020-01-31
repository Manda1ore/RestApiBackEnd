using PeopleDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulAPIDemo.Controllers
{
    public class PersonController : ApiController
    {

        // GET api/person
        public IEnumerable<Person> Get()
        {
            using (RestfulTestEntities entities = new RestfulTestEntities())
            {
                return entities.People.ToList();
            }
        }

        public Person Get(int id)
        {
            using (RestfulTestEntities entities = new RestfulTestEntities())
            {
                return entities.People.FirstOrDefault(e => e.id == id);
            }
        }

        public HttpResponseMessage Post([FromBody]Person person)
        {
            using (RestfulTestEntities entities = new RestfulTestEntities())
            {
                try
                {
                    entities.People.Add(person);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, person);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, e);
                }
            }
        }
    }
}
