using DDD_IOC_Unitofwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DDD_IOC_Unitofwork.Controllers
{
    public class ABCController : ApiController
    {
        public ABCApp abcApp { get; set; }

        [HttpGet]
        public bool IsSame( ) 
        {
            return abcApp.IsSame();
        }
    }
}
