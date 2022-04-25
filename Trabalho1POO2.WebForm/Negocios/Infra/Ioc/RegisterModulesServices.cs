using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho1POO2.WebForm.Negocios.Infra.Data.InMemory;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Ioc
{
    public static class RegisterModulesServices
    {
        public static void RegisterAll()
        {
            ServiceLocator.Register<IProdutoRepositorio, ProdutosInMemory>();
            ServiceLocator.Register<IFormaPagamentoRepositorio, FormaPagamentoInMemory>();
            ServiceLocator.Register<IClienteRepositorio, ClienteInMemory>();
            ServiceLocator.Register<IPagamentoRepositorio, PagamentoInMemory>();
        }
    }
}