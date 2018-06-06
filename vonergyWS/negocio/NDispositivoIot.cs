using System.Collections.Generic;
using vonergyDom.domain;
using vonergyWS.DAO.dal;
using vonergyWS.DAO.Interface;

namespace vonergyWS.negocio
{
    public class NDispositivoIot<T> : IDao<DispositivoIOT>
    {
        private DispositivoIotDao<T> _dispositivoIotDao;

        public NDispositivoIot()
        {
            _dispositivoIotDao = new DispositivoIotDao<T>();
        }

        public DispositivoIOT Cadastrar(DispositivoIOT objeto)
        {
            return _dispositivoIotDao.Cadastrar(objeto);
        }

        public DispositivoIOT Atualizar(DispositivoIOT objeto)
        {
            return _dispositivoIotDao.Atualizar(objeto);
        }
        
        public IList<DispositivoIOT> Listar()
        {
            return _dispositivoIotDao.Listar();
        }

        public IList<DispositivoIOT> ListarAtivos()
        {
            return _dispositivoIotDao.ListarAtivos();
        }

        public DispositivoIOT ListarId(long? id)
        {
            return _dispositivoIotDao.ListarId(id);
        }

        public IList<DispositivoIOT> ListarInativos()
        {
            return _dispositivoIotDao.ListarInativos();
        }

        public void Remover(long? id)
        {
             _dispositivoIotDao.Remover(id);
        }
    }
}