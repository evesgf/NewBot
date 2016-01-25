using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewBot.Common;

namespace NewBot.Controllers
{
    public class MainController : ApiBase
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            return JsonHelper.GoToJson("this is main");
        }
    }
}
