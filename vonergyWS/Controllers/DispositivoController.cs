using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vonergyDom.domain;
using vonergyWS.negocio;

namespace vonergyWS.Controllers
{

    [RoutePrefix("api/Dispositivo")]
    public class DispositivoController : ApiController
    {

        private NDispositivoIot nDispositivoIot;
        public DispositivoController()
        {
            nDispositivoIot = new NDispositivoIot();
        }

        [Route("Cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(DispositivoIOT dispositivoIOT)
        {
            try
            {
                nDispositivoIot.Cadastrar(dispositivoIOT);

                if (ModelState.IsValid)
                {
                    //...
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [Route("Listar")]

        [HttpGet]
        public IList<DispositivoIOT> Listar()
        {
            return nDispositivoIot.Listar();
        }

        [Route("ListarId")]
        [HttpGet]
        public DispositivoIOT ListarId(long id)
        {
            return nDispositivoIot.ListarId(id);
        }

        [Route("Alterar")]
        //[HttpPost]
        public Funcionario Atualizar(long id)
        {
            try
            {
                return null;//_funcionarioNegocio.Atualizar(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public void Delete(long Id)
        {
            nDispositivoIot.Delete(Id);
        }

       
    }
}
