using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using vonergyDom.domain;
using vonergyWS.negocio;

namespace vonergyWS.Controllers
{

    [RoutePrefix("api/Iot")]
    public class IotController : ApiController
    {
        private NDispositivoIot<DispositivoIOT> nDispositivoIot;

        public IotController()
        {
            nDispositivoIot = new NDispositivoIot<DispositivoIOT>();
        }

        [Route("Cadastrar")]
        [HttpPost]
        public DispositivoIOT Cadastrar(DispositivoIOT dispositivoIOT)
        {
            try
            {
                if (dispositivoIOT != null)
                {
                    return nDispositivoIot.Cadastrar(dispositivoIOT);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("listar")]
        [HttpGet]
        public IList<DispositivoIOT> listar()
        {
            return nDispositivoIot.Listar();
        }

        [Route("listarId")]
        [HttpGet]
        public DispositivoIOT listarid(long id)
        {
            return nDispositivoIot.ListarId(id);
        }

        [Route("Alterar")]
        [HttpPut]
        public DispositivoIOT Atualizar(DispositivoIOT dispositivoIOT)
        {
            try
            {
                return nDispositivoIot.Atualizar(dispositivoIOT);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("Deletar")]
        [HttpDelete]
        public void delete(long id)
        {
            nDispositivoIot.Remover(id);
        }


    }
}
