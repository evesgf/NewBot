using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewBot.BLL;
using NewBot.Common;
using System.Threading.Tasks;

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

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Create()
        {
            var a = _iUsersBll.Create();
            return JsonHelper.GoToJson(a);
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Update()
        {
            var a = _iUsersBll.Delete();
            return JsonHelper.GoToJson(a);
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Delete()
        {
            var a = _iUsersBll.Delete();
            return JsonHelper.GoToJson(a);
        }

        /// <summary>
        /// 测试异步接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task OperationAsync()
        {
            await Task.Delay(2000);
        }

        ///文件上传
        
        ///登录
        
        ///缓存
    }
}
