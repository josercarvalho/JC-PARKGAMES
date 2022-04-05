using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using System.Linq;
using System.Globalization;
using System.Data.Entity;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeDespesas : RepositorioBase<Despesa>, IRepositorioDeDespesas
    {
        public IEnumerable<Despesa> BuscaPorDatas(string dataInicial, string dataFinal)
        {
            if(string.IsNullOrEmpty(dataInicial) || string.IsNullOrEmpty(dataFinal))
            {
                throw new Exception("Data(s) inválida(s) ou vazia(s)");
            }
            var dataIni = Convert.ToDateTime(dataInicial);
            var dataFin = Convert.ToDateTime(dataFinal);

            return _contexto.Despesas.Where(d => d.DataCadastro >= dataIni && d.DataCadastro <= dataFin).ToList();
        }

        public IEnumerable<Despesa> BuscaPorEvento(int evento)
        {
            return _contexto.Despesas.Include(p => p.Eventos).Where(d => d.EventoId == evento);
        }

        public IEnumerable<Despesa> BuscaPorMes(DateTime data)
        {
            var culture = new CultureInfo("pt-BR");
            var formataData = culture.DateTimeFormat;
            var mes = Convert.ToInt32(data.Month);
            var ano = Convert.ToInt32(data.Year);
            var nomeMes = culture.TextInfo.ToTitleCase(formataData.GetMonthName(mes));

            return _contexto.Despesas.Where(d => d.DataCadastro.Month == mes && d.DataCadastro.Year == ano).ToList();
        }
    }
}
