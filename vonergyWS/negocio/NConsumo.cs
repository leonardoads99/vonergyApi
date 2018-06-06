using System.Collections.Generic;
using System.Linq;
using vonergyDom.domain;
using vonergyWS.DAO.dal;

namespace vonergyWS.negocio
{
    public class NConsumo
    {

        ConsumoDao consumoDao;

        public NConsumo()
        {
            consumoDao = new ConsumoDao();
        }

        public void CadastrarConsumoEletrico(Consumo consumo)
        {
            consumoDao.CadastrarConsumoEletrico(consumo);
        }

        public IList<Consumo> ListarConsumoAll()
        {
            return consumoDao.ListarConsumoAll();
        }

        public IList<ConsumoRegistrado> ListarConsumoPorHora()
        {
            return consumoDao.ListarConsumoPorHora();
        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoPorHoraDicionario()
        {
            return consumoDao.ListarConsumoPorHoraDicionario();
        }

        public IList<ConsumoRegistrado> ListarConsumoDiario()
        {
            return consumoDao.ListarConsumoDiario();
        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoDiarioDicionario()
        {
            return consumoDao.ListarConsumoDiarioDicionario();
        }

        public IList<ConsumoRegistrado> ListarConsumoSemanal()
        {
            return consumoDao.ListarConsumoSemanal();
        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoSemanalDicionario()
        {
            return consumoDao.ListarConsumoMensalDicionario();

        }

        public IList<ConsumoRegistrado> ListarConsumoMesal()
        {
            return consumoDao.ListarConsumoMesal();

        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoMensalDicionario()
        {
            return consumoDao.ListarConsumoMensalDicionario();

        }

        public IList<ConsumoRegistrado> ListarConsumoAnual()
        {
            return consumoDao.ListarConsumoAnual();
        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoAnualDicionario()
        {
            return consumoDao.ListarConsumoAnualDicionario();

        }



        public decimal ConsumoReal()
        {
            return consumoDao.ConsumoReal();
        }
    }
}