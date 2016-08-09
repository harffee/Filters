using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize(Users ="adam,steve,jacqui",Roles ="admin")]
        public string Index()
        {
            return "This is the Index action on the home controller";
        }
        [HandleError(ExceptionType =typeof(ArgumentOutOfRangeException),View ="RangeError")]
        public string RangeTest(int id)
        {
            if(id>100)
            {
                return String.Format("The id value is:{0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id");
            }
        }
        [ProfileAction]
        public string FilterTest()
        {
            return "This is the ActionFilterTest action";
        }
    }
}