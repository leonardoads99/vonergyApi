using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using vonergyDom.domain;
using vonergyWS.context;
using vonergyWS.DAO.Interface;

namespace vonergyWS.DAO.dal
{
    public class FuncionarioDao<T> : IDao<Funcionario>
    {

        private readonly Context context;

        public FuncionarioDao()
        {
            context = new Context();
        }

        public Funcionario Login(Funcionario funcionario)
        {
            var funcionarioselecionado = (from listacarregada in context.Funcionarios
                                          where (listacarregada.Email == funcionario.Email && listacarregada.Senha == funcionario.Senha)
                                          select listacarregada).FirstOrDefault();

            if (funcionarioselecionado == null)
            {
                return null;
            }
            return funcionarioselecionado;
        }

        public Funcionario Atualizar(Funcionario objeto)
        {
            if (objeto != null)
            {
                if (context.Entry(objeto).State == EntityState.Detached)
                {
                    context.Set<Funcionario>().Attach(objeto);
                }
                context.Entry(objeto).State = EntityState.Modified;
                context.SaveChanges();
            }
            return objeto;
        }

        public Funcionario Cadastrar(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                return null;
            }
            var funcionarioCadastrado = context.Funcionarios.Add(funcionario);
            context.SaveChanges();
            return funcionarioCadastrado;
        }

        public IList<Funcionario> Listar()
        {
            return context.Funcionarios.ToList();
        }
         
        public IList<Funcionario> ListarAtivos()
        {
            IList<Funcionario> funcionariosBD = Listar();
            return funcionariosBD.Where(p => p.Status == vonergyDom.domain.Enumm.Status.Ativo).ToList();
        }

        public IList<Funcionario> ListarInativos()
        {
            IList<Funcionario> funcionariosBD = Listar();
            return funcionariosBD.Where(p => p.Status == vonergyDom.domain.Enumm.Status.Inativo).ToList();
        }

        public Funcionario ListarId(long? id)
        {
            return context.Funcionarios.Find(id);
        }

        public void Remover(long? id)
        {
            var funcionario = ListarId(id);
            context.Funcionarios.Remove(funcionario);
            context.SaveChanges();
        }
    }
}