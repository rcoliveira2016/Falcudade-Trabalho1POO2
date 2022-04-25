using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Data.InMemory
{
    public class FormaPagamentoInMemory : InMemoryBase<FormaPagamento>, IFormaPagamentoRepositorio
    {
        private static readonly List<FormaPagamento> _data = new List<FormaPagamento>();
        protected override IList<FormaPagamento> Data => _data;
    }
}