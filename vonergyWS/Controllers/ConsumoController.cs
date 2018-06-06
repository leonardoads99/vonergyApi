using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using vonergyDom.domain;
using vonergyWS.negocio;

namespace vonergyWS.Controllers
{
    [RoutePrefix("api/Consumo")]
    public class ConsumoController : ApiController
    {
        private NConsumo NConsumo;

        public ConsumoController()
        {
            NConsumo = new NConsumo();
        }

        [Route("ConsumoReal")]
        [HttpGet]
        public decimal ConsumoReal()
        {
            return NConsumo.ConsumoReal();
        }

        [Route("CadastroConsumo")]
        [HttpPost]
        public void CadastrarConsumoEletrico(Consumo consumo)
        {
            NConsumo.CadastrarConsumoEletrico(consumo);
        }

        [Route("ConsumoGeral")]
        [HttpGet]
        public IList<Consumo> ListarConsumoAll()
        {
            return NConsumo.ListarConsumoAll();
        }

        //--------------Consulta por HORA---------------------
        [Route("ConsumoHora")]
        [HttpGet]
        public IList<ConsumoRegistrado> ListarConsumoPorHora()
        {
            return NConsumo.ListarConsumoPorHora();
        }

        [Route("ConsumoHoraDicionario")]
        [HttpGet]
        public Dictionary<int, ConsumoRegistrado> ListarConsumoPorHoraDicionario()
        {
            return NConsumo.ListarConsumoPorHoraDicionario();
        }

        //--------------Consulta por DIA---------------------
        [Route("ConsumoDiario")]
        [HttpGet]
        public IList<ConsumoRegistrado> ListarConsumoDiario()
        {
            return NConsumo.ListarConsumoDiario();
        }

        [Route("ConsumoDiarioDicionario")]
        [HttpGet]
        public Dictionary<int, ConsumoRegistrado> ListarConsumoDiarioDicionario()
        {
            return NConsumo.ListarConsumoDiarioDicionario();
        }

        //--------------Consulta por SEMANA---------------------
        [Route("ConsumoSemanal")]
        [HttpGet]
        public IList<ConsumoRegistrado> ListarConsumoSemanal()
        {
            return NConsumo.ListarConsumoSemanal();
        }

        [Route("ConsumoSemanalDicionario")]
        [HttpGet]
        public Dictionary<int, ConsumoRegistrado> ListarConsumoSemanalDicionario()
        {
            return NConsumo.ListarConsumoSemanalDicionario();
        }

        //--------------Consulta por MES---------------------
        [Route("ConsumoMesal")]
        [HttpGet]
        public IList<ConsumoRegistrado> ListarConsumoMesal()
        {
            return NConsumo.ListarConsumoMesal();
        }

        [Route("ConsumoMensalDicionario")]
        [HttpGet]
        public Dictionary<int, ConsumoRegistrado> ListarConsumoMensalDicionario()
        {
            return NConsumo.ListarConsumoMensalDicionario();
        }

        //--------------Consulta por ANO---------------------
        [Route("ConsumoAnual")]
        [HttpGet]
        public IList<ConsumoRegistrado> ListarConsumoAnual()
        {
            return NConsumo.ListarConsumoAnual();
        }

        [Route("ConsumoAnualDicionario")]
        [HttpGet]
        public Dictionary<int, ConsumoRegistrado> ListarConsumoAnualDicionario()
        {
            return NConsumo.ListarConsumoAnualDicionario();
        }

    }
}
