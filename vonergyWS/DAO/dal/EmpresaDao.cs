using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using vonergyDom.domain;
using vonergyWS.context;
using vonergyWS.DAO.Interface;

namespace vonergyWS.DAO.dal
{
    public class EmpresaDao<T> : IDao<Empresa>
    {
        private readonly Context context;

        public EmpresaDao()
        {
            context = new Context();
        }

        public Empresa Atualizar(Empresa objeto)
        {
            if (objeto != null)
            {
                if (context.Entry(objeto).State == EntityState.Detached)
                {
                    context.Set<Empresa>().Attach(objeto);
                }
                context.Entry(objeto).State = EntityState.Modified;
                context.SaveChanges();

            }
            return objeto;
        }

        public Empresa Cadastrar(Empresa objeto)
        {
            var empresa = context.Empresas.Add(objeto);
            context.SaveChanges();
            return empresa;
        }

        public IList<Empresa> Listar()
        {
            return context.Empresas.ToList();
        }

        public IList<Empresa> ListarAtivos()
        {
            IList<Empresa> empresaBD = Listar();

            return context.Empresas.ToList();
        }

        public IList<Empresa> ListarInativos()
        {
            IList<Empresa> empresaBD = Listar();

            return context.Empresas.ToList();
        }

        public Empresa ListarId(long? id)
        {
            return context.Empresas.Find(id);
        }



        public void Remover(long? id)
        {
            if (id != null)
            {
                var Empresa = context.Empresas.Find(id);
                context.Empresas.Remove(Empresa);
                context.SaveChanges();
            }


        }
    }
}