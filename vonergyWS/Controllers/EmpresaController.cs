using System;
using System.Collections.Generic;
using System.Web.Http;
using vonergyDom.domain;
using vonergyWS.DAO.dal;
using vonergyWS.negocio;

namespace vonergyWS.Controllers
{
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {

        private NEmpresa<Empresa> _NEmpresa = new NEmpresa<Empresa>();

        [Route("Cadastrar")]
        [HttpPost]
        public Empresa Cadastrar(Empresa empresa)
        {
            return _NEmpresa.Cadastrar(empresa);
        }

        [Route("Alterar")]
        [HttpPut]
        public Empresa Atualizar(Empresa empresa)
        {
            try
            {
                return _NEmpresa.Atualizar(empresa);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("Listar")]
        [HttpGet]
        public IList<Empresa> Listar()
        {
            return _NEmpresa.Listar();
        }

        [Route("ListarId")]
        [HttpGet]
        public Empresa ListarId(long id)
        {
            return _NEmpresa.ListarId(id);
        }

        [Route("Delete")]
        [HttpGet]
        public void Delete(long? Id)
        {
            _NEmpresa.Remover(Id);
        }
    }
}
