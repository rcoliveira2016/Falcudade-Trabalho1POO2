using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Data.InMemory
{
    public class ProdutosInMemory : InMemoryBase<Produto>, IProdutoRepositorio
    {
        private static readonly List<Produto> _data = new List<Produto>();
        protected override IList<Produto> Data => _data;
    }
}