using System.Collections.Generic;
using vonergyDom.domain;
using vonergyWS.DAO.dal;
using vonergyWS.DAO.Interface;

namespace vonergyWS.negocio
{
    public class NEmpresa<T> : IDao<Empresa>
    {
        EmpresaDao<Empresa> _EmpresaDao;

        public NEmpresa()
        {
            _EmpresaDao = new EmpresaDao<Empresa>();
        }

        public Empresa Atualizar(Empresa objeto)
        {
            return _EmpresaDao.Atualizar(objeto);
        }

        public Empresa Cadastrar(Empresa objeto)
        {
            if (objeto == null)
            {
                return null;
            }
            var EmpresaCadastrado = _EmpresaDao.Cadastrar(objeto);
            return EmpresaCadastrado;
        }

        public IList<Empresa> Listar()
        {
            return _EmpresaDao.Listar();
        }

        public IList<Empresa> ListarAtivos()
        {
            throw new System.NotImplementedException();
        }

        public Empresa ListarId(long? id)
        {
            return _EmpresaDao.ListarId(id);
        }

        public IList<Empresa> ListarInativos()
        {
            throw new System.NotImplementedException();
        }

        public void Remover(long? id)
        {
            _EmpresaDao.Remover(id);
        }
    }
}