using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewBot.BLL;
using NewBot.Common;

namespace NewBot.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IUsersBLL _iUsersBll;

        public HomeController(IUsersBLL iUsersBll)
        {
            _iUsersBll = iUsersBll;
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Index()
        {
            var a = _iUsersBll.Hello();
            return JsonHelper.GoToJson(a);
        }
    }
}
