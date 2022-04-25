using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Data.InMemory
{
    public class PagamentoInMemory : InMemoryBase<Pagamento>, IPagamentoRepositorio
    {
        private static readonly List<Pagamento> _data = new List<Pagamento>();
        protected override IList<Pagamento> Data => _data;
    }
}