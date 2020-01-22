using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using back.Database;

namespace back.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly bdtmEntities BD = new bdtmEntities();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IQueryable<object> Get(string name, int page)
        {
            var query = from C in BD.Course
                        where (C.Name.Contains(name) || name.Equals(null))
                        select new { C.Id, C.ImageUrl, C.Name, C.ImageText, C.MaximumCredits, C.Price, C.Rating };

            var fquery = query.OrderBy(x => x.Id).Skip(page * 24).Take(24);

            return fquery;
        }
    }
}
