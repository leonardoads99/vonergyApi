using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using vonergyDom.domain;
using vonergyWS.negocio;

namespace vonergyWS.Controllers
{
    [RoutePrefix("api/Funcionario")]
    public class FuncionarioController : ApiController
    {
        private readonly NFuncionario<Funcionario> _funcionarioNegocio;

        public FuncionarioController()
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
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
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
        public Funcionario ListarId(long? id)
        {
            return _funcionarioNegocio.ListarId(id);
        }

        [Route("Alterar")]
        [HttpPut]
        public Funcionario Atualizar(Funcionario funcionario)
        {
            try
            {
                return _funcionarioNegocio.Atualizar(funcionario);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("Delete")]
        [HttpGet]
        public void Delete(long? Id)
        {
            _funcionarioNegocio.Remover(Id);
        }

        [Route("Acessar")]
        [HttpPost]
        public Funcionario Acessar(Funcionario funcionario)
        {
            return _funcionarioNegocio.Acessar(funcionario);
        }

        [Route("AtualizarFuncionario")]
        [HttpPost]
        public HttpResponseMessage AtualizarFuncionario(Funcionario funcionario)
        {
            try
            {
                _funcionarioNegocio.AtualizarFuncionario(funcionario);

                if (ModelState.IsValid)
                {
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
