using System.Collections.Generic;
using vonergyDom.domain;
using vonergyWS.DAO.dal;
using vonergyWS.DAO.Interface;

namespace vonergyWS.negocio
{
    public class NEquipamentos<T> : IDao<Equipamentos>
    {
        private EquipamentoDao<T> equipamentoDao;

        public NEquipamentos()
        {
            equipamentoDao = new EquipamentoDao<T>();
        }
        public Equipamentos Atualizar(Equipamentos objeto)
        {
            return equipamentoDao.Atualizar(objeto);
        }

        public Equipamentos Cadastrar(Equipamentos objeto)
        {
            return equipamentoDao.Cadastrar(objeto);
        }

        public IList<Equipamentos> Listar()
        {
            return equipamentoDao.Listar();
        }

        public IList<Equipamentos> ListarAtivos()
        {
            return equipamentoDao.ListarAtivos();
        }

        public Equipamentos ListarId(long? id)
        {
            return equipamentoDao.ListarId(id);
        }

        public IList<Equipamentos> ListarInativos()
        {
            return equipamentoDao.ListarInativos();
        }

        public void Remover(long? id)
        {
            equipamentoDao.Remover(id);
        }
    }
}