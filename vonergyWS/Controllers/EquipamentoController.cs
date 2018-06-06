using System;
using System.Collections.Generic;
using System.Web.Http;
using vonergyDom.domain;
using vonergyWS.negocio;

namespace vonergyWS.Controllers
{
    [RoutePrefix("api/Equipamento")]
    public class EquipamentoController : ApiController
    {
        private NEquipamentos<Equipamentos> nEquipamentos;

        public EquipamentoController()
        {
            nEquipamentos = new NEquipamentos<Equipamentos>();
        }

        [Route("Cadastrar")]
        [HttpPost]
        public Equipamentos Cadastrar(Equipamentos equipamentos)
        {
            try
            {
                if (equipamentos != null)
                {
                  return  nEquipamentos.Cadastrar(equipamentos);
                }else
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("listar")]
        [HttpGet] 
        public IList<Equipamentos> Listar()
        {
            return nEquipamentos.Listar();
        }

        [Route("listarId")]
        [HttpGet]
        public Equipamentos Listarid(long id)
        {
            return nEquipamentos.ListarId(id);
        }

        [Route("Alterar")]
        [HttpPut]
        public Equipamentos Atualizar(Equipamentos equipamentos)
        {
            try
            {
                return nEquipamentos.Atualizar(equipamentos);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("Deletar")]
        [HttpDelete]
        public void Delete(long id)
        {
            nEquipamentos.Remover(id);
        }

    }
}