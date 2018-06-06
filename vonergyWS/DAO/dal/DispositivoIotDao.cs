using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using vonergyDom.domain;
using vonergyWS.context;
using vonergyWS.DAO.Interface;

namespace vonergyWS.DAO.dal
{
    public class DispositivoIotDao<T> : IDao<DispositivoIOT>
    {
        private Context context;

        public DispositivoIotDao()
        {
            context = new Context();
        }

        public DispositivoIOT Cadastrar(DispositivoIOT objeto)
        {
            try
            {
                var IotCarregado = context.DispositivoIOT.Add(objeto);
                context.SaveChanges();
                if (IotCarregado == null)
                {
                    return null;
                }
                return IotCarregado;
            }
            catch (JsonException jsonException)
            {
                throw new Exception(jsonException.Message);
            }
        }

        public DispositivoIOT Atualizar(DispositivoIOT objeto)
        {
            return null;
        }

        public IList<DispositivoIOT> Listar()
        {
          IList<DispositivoIOT> DispositivoCarregado =  context.DispositivoIOT.ToList();

            if (DispositivoCarregado == null)
            {
                return null;
            }

            return DispositivoCarregado;
        }

        public DispositivoIOT ListarId(long? id)
        {
            return context.DispositivoIOT.Find(id);
        }

        public IList<DispositivoIOT> ListarAtivos()
        {
            IList<DispositivoIOT> funcionariosBD = context.DispositivoIOT.ToList();
            return funcionariosBD.Where(p => p.Status == vonergyDom.domain.Enumm.Status.Ativo).ToList();
        }
        
        public IList<DispositivoIOT> ListarInativos()
        {
            IList<DispositivoIOT> funcionariosBD = context.DispositivoIOT.ToList();
            return funcionariosBD.Where(p => p.Status == vonergyDom.domain.Enumm.Status.Inativo).ToList();
        }

        public void Remover(long? id)
        {
            var iot = ListarId(id);
            context.DispositivoIOT.Remove(iot);
            context.SaveChanges();
        }
               
    }
}