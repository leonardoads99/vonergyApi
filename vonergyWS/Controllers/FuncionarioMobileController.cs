using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vonergyDom.domain;
using vonergyWS.negocio;

namespace vonergyWS.Controllers
{
    [RoutePrefix("api/FuncionarioMobile")]
    public class FuncionarioMobileController : ApiController
    {
        private readonly NFuncionario<Funcionario> _funcionarioNegocio;

        public FuncionarioMobileController()
        {
            _funcionarioNegocio = new NFuncionario<Funcionario>();
        }

        [Route("Cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(Funcionario funcionario)
        {
            try
            {
               _funcionarioNegocio.Cadastrar(funcionario);

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
        public IList<Funcionario> Listar()
        {
            return _funcionarioNegocio.Listar();
        }

        [Route("ListarId")]
        [HttpGet]
        public Funcionario ListarId(long id)
        {
            return _funcionarioNegocio.ListarId(id);
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
            _funcionarioNegocio.Remover(Id);
        }

        [Route("Acessar")]
        [HttpPost]
        public Funcionario Acessar(Funcionario funcionario)
        {
            return _funcionarioNegocio.Acessar(funcionario);
        }
    }
}
