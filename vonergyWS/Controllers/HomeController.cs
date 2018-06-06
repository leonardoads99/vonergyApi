using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using vonergyDom.domain;

namespace vonergyWS.Controllers
{

    [EnableCors(origins: "http://localhost:20381", methods: "GET, POST", headers: "*")]
    public class HomeController : ApiController
    {
        public string Index()
        {
            return "value";
        }


        public Funcionario Acessar(string login , string senha)
        {
            return null;
        }
    }
}
