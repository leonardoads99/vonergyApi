using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vonergyDom.domain;
using vonergyWS.context;
using vonergyWS.RegraNegocio;

namespace vonergyWS.DAO.dal
{
    public class ConsumoDao
    {
        Context context;
        private IList<Consumo> Consumos;

        public ConsumoDao()
        {
            context = new Context();
            var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var firstDay = startOfTthisMonth.AddMonths(-1);
            var lastDay = startOfTthisMonth.AddDays(-1);
        }

        public void CadastrarConsumoEletrico(Consumo consumo)
        {
            consumo.Potencia = CalculoEnergia.conversaoPotenciao(consumo.Potencia);
            context.Consumos.Add(consumo);
            context.SaveChanges();
        }

        public IList<Consumo> ListarConsumoAll()
        {
            return context.Consumos.ToList();
        }

        public IList<ConsumoRegistrado> ListarConsumoPorHora()
        {
            List<ConsumoRegistrado> listaconsumoRegistrado = new List<ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Hour into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     //  dataRegistro = chave.   (p=>p.DataRegistro),
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    //    DataRegistro = item.dataRegistro
                };
                listaconsumoRegistrado.Add(consumoRegistrado);
            }
            return listaconsumoRegistrado;
        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoPorHoraDicionario()
        {
            Dictionary<int, ConsumoRegistrado> listaconsumoRegistrado = new Dictionary<int, ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Hour into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     // dataRegistro = chave.Key.DataRegistro,
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    DataRegistro = CalculoEnergia.CorrecaoDataHora(item.id)
                };
                listaconsumoRegistrado.Add(id, consumoRegistrado);
            }
            return listaconsumoRegistrado;
        }

        public IList<ConsumoRegistrado> ListarConsumoDiario()
        {
            List<ConsumoRegistrado> listaconsumoRegistrado = new List<ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Day into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     //  dataRegistro = chave.   (p=>p.DataRegistro),
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    DataRegistro = CalculoEnergia.CorrecaoDataDiario(item.id)
                };
                listaconsumoRegistrado.Add(consumoRegistrado);
            }
            return listaconsumoRegistrado;

        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoDiarioDicionario()
        {
            Dictionary<int, ConsumoRegistrado> listaconsumoRegistrado = new Dictionary<int, ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Day into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     // dataRegistro = chave.Key.DataRegistro,
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    DataRegistro = CalculoEnergia.CorrecaoDataDiario(item.id)
                };
                listaconsumoRegistrado.Add(id, consumoRegistrado);
            }
            return listaconsumoRegistrado;
        }

        //Corrigir
        public IList<ConsumoRegistrado> ListarConsumoSemanal()
        {
            List<ConsumoRegistrado> listaconsumoRegistrado = new List<ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.DayOfWeek into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     //  dataRegistro = chave.   (p=>p.DataRegistro),
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    //    DataRegistro = item.dataRegistro
                };
                listaconsumoRegistrado.Add(consumoRegistrado);
            }
            return listaconsumoRegistrado;

        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoSemanalDicionario()
        {
            Dictionary<int, ConsumoRegistrado> listaconsumoRegistrado = new Dictionary<int, ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Month into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     // dataRegistro = chave.Key.DataRegistro,
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    //  DataRegistro = item.dataRegistro
                };
                listaconsumoRegistrado.Add(id, consumoRegistrado);
            }
            return listaconsumoRegistrado;
        }

        public IList<ConsumoRegistrado> ListarConsumoMesal()
        {
            List<ConsumoRegistrado> listaconsumoRegistrado = new List<ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Month into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     //  dataRegistro = chave.   (p=>p.DataRegistro),
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    DataRegistro = CalculoEnergia.CorrecaoDataMensal(item.id)
                };
                listaconsumoRegistrado.Add(consumoRegistrado);
            }
            return listaconsumoRegistrado;

        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoMensalDicionario()
        {
            Dictionary<int, ConsumoRegistrado> listaconsumoRegistrado = new Dictionary<int, ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Month into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     // dataRegistro = chave.Key.DataRegistro,
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    DataRegistro = CalculoEnergia.CorrecaoDataMensal(item.id)
                };
                listaconsumoRegistrado.Add(id, consumoRegistrado);
            }
            return listaconsumoRegistrado;
        }

        public IList<ConsumoRegistrado> ListarConsumoAnual()
        {
            List<ConsumoRegistrado> listaconsumoRegistrado = new List<ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Year into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     //  dataRegistro = chave.   (p=>p.DataRegistro),
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    DataRegistro = CalculoEnergia.CorrecaoDataAnual(item.id)
                };
                listaconsumoRegistrado.Add(consumoRegistrado);
            }
            return listaconsumoRegistrado;

        }

        public Dictionary<int, ConsumoRegistrado> ListarConsumoAnualDicionario()
        {
            Dictionary<int, ConsumoRegistrado> listaconsumoRegistrado = new Dictionary<int, ConsumoRegistrado>();
            ConsumoRegistrado consumoRegistrado;
            int id = 0;

            var consumoMensal = (from consumo in context.Consumos
                                 group consumo by consumo.DataRegistro.Year into chave
                                 select new
                                 {
                                     id = chave.Key,
                                     potencia = chave.Sum(s => s.Potencia),
                                     // dataRegistro = chave.Key.DataRegistro,
                                     // HoraCadastrada = chave.Key.DataRegistro.Hour
                                 }).OrderBy(p => p.id).ToList();

            foreach (var item in consumoMensal)
            {
                consumoRegistrado = new ConsumoRegistrado
                {
                    Id = id++,
                    Potencia = item.potencia,
                    DataRegistro = CalculoEnergia.CorrecaoDataAnual(item.id)
                };
                listaconsumoRegistrado.Add(id, consumoRegistrado);
            }
            return listaconsumoRegistrado;
        }

        public decimal ConsumoReal()
        {
            var consumoCarregado = (from consumo in context.Consumos select consumo).Sum(p => p.Potencia);
            return consumoCarregado;
        }
    }
}