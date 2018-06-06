using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using vonergyDom.domain;
using vonergyWS.context;
using vonergyWS.DAO.Interface;

namespace vonergyWS.DAO.dal
{
    public class EquipamentoDao<T> : IDao<Equipamentos>
    {
        private readonly Context context;

        public EquipamentoDao()
        {
            context = new Context();
        }

        public Equipamentos Atualizar(Equipamentos objeto)
        {
            if (objeto != null)
            {
                if (context.Entry(objeto).State == EntityState.Detached)
                {
                    context.Set<Equipamentos>().Attach(objeto);
                }
                context.Entry(objeto).State = EntityState.Modified;
                context.SaveChanges();
            }
            return objeto;
        }

        public Equipamentos Cadastrar(Equipamentos objeto)
        {
            var EquipamentoCadastrado = context.Equipamentos.Add(objeto);
            context.SaveChanges();
            return EquipamentoCadastrado;
        }

        public IList<Equipamentos> Listar()
        {
            return context.Equipamentos.ToList();
        }

        public IList<Equipamentos> ListarAtivos()
        {
            return context.Equipamentos.ToList();
        }

        public IList<Equipamentos> ListarInativos()
        {
            return context.Equipamentos.ToList();
        }

        public Equipamentos ListarId(long? id)
        {
            return context.Equipamentos.Find(id);
        }

        public void Remover(long? id)
        {
            var equipamentoRemovido = ListarId(id);
            context.Equipamentos.Remove(equipamentoRemovido);
            context.SaveChanges();
        }
    }
}