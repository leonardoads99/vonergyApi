using System;
using System.Collections.Generic;
using vonergyDom.domain;
using vonergyWS.DAO.dal;
using vonergyWS.DAO.Interface;

namespace vonergyWS.negocio
{

    public class NFuncionario<T> : IDao<Funcionario>
    {

        private FuncionarioDao<Funcionario> _funcionarioDao;

        public NFuncionario()
        {
            _funcionarioDao = new FuncionarioDao<Funcionario>();
        }

        public NFuncionario(FuncionarioDao<Funcionario> funcionarioDao)
        {
            _funcionarioDao = funcionarioDao;
        }

        public Funcionario Atualizar(Funcionario objeto)
        {
          return  _funcionarioDao.Atualizar(objeto);
        }

        public Funcionario Cadastrar(Funcionario objeto)
        {
            if (objeto == null)
            {
                return null;
            }
            var funcionarioCadastrado = _funcionarioDao.Cadastrar(objeto);
            return funcionarioCadastrado;
        }

        public IList<Funcionario> Listar()
        {
            return _funcionarioDao.Listar();
        }

        public IList<Funcionario> ListarAtivos()
        {
            throw new NotImplementedException();
        }

        public Funcionario ListarId(long? id)
        {
            return _funcionarioDao.ListarId(id);
        }

        public IList<Funcionario> ListarInativos()
        {
            throw new NotImplementedException();
        }

        public void Remover(long? id)
        {
            _funcionarioDao.Remover(id);
        }


        public Funcionario Acessar(Funcionario funcionario)
        {
            return _funcionarioDao.Login(funcionario);
        }

        public void AtualizarFuncionario(Funcionario objeto)
        {

            _funcionarioDao.Atualizar(objeto);

        }

    }
}
