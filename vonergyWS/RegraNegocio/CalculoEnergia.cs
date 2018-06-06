using System;

namespace vonergyWS.RegraNegocio
{
    public static class CalculoEnergia
    {
        const decimal conversor = 3600000M;
        //  const decimal segundos = 3600M;
        const decimal taxa = 0.57M;

        public static decimal conversaoPotenciao(decimal potencia)
        {
            var potenciaconvertida = potencia / conversor;
            //  potenciaconvertida =  decimal.Multiply(potenciaconvertida, segundos);
            return decimal.Multiply(potenciaconvertida, taxa);

        }

        public static DateTime CorrecaoDataMensal(int data)
        {
            var dataCorrigida =new DateTime(DateTime.Today.Year, data,1);
            //var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            //var firstDay = startOfTthisMonth.AddMonths(-1);
            //var lastDay = startOfTthisMonth.AddDays(-1);
            return dataCorrigida;
        }

        public static DateTime CorrecaoDataAnual(int data)
        {
            var dataCorrigida = new DateTime(data, DateTime.Today.Month, DateTime.Today.Day);
            //var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            //var firstDay = startOfTthisMonth.AddMonths(-1);
            //var lastDay = startOfTthisMonth.AddDays(-1);
            return dataCorrigida;
        }

        public static DateTime CorrecaoDataDiario(int data)
        {
            var dataCorrigida = new DateTime(DateTime.Today.Year, DateTime.Today.Month,data);
            //var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            //var firstDay = startOfTthisMonth.AddMonths(-1);
            //var lastDay = startOfTthisMonth.AddDays(-1);
            return dataCorrigida;
        }

        public static DateTime CorrecaoDataHora(int data)
        {
            var dataCorrigida = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,data,DateTime.Today.Minute,DateTime.Today.Second);
            //var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            //var firstDay = startOfTthisMonth.AddMonths(-1);
            //var lastDay = startOfTthisMonth.AddDays(-1);
            return dataCorrigida;
        }

    }
}