using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Infra.Ioc;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterModulesServices.RegisterAll();
            CriarDadosIniciais();
        }

        private void CriarDadosIniciais()
        {
            var produtos = ServiceLocator.Get<IProdutoRepositorio>();
            var formaspAgamento = ServiceLocator.Get<IFormaPagamentoRepositorio>();
            var clientes = ServiceLocator.Get<IClienteRepositorio>();

            produtos.Adicionar(new Produto("Produto 1", 10.50));
            produtos.Adicionar(new Produto("Produto 2", 1));
            produtos.Adicionar(new Produto("Produto 3", 5));
            produtos.Adicionar(new Produto("Produto 4", 8.99));

            formaspAgamento.Adicionar(new FormaPagamento("Cartão de Crédito", 0));
            formaspAgamento.Adicionar(new FormaPagamento("Cartão de Débito", 5));
            formaspAgamento.Adicionar(new FormaPagamento("Boleto Bancário", 8));
            formaspAgamento.Adicionar(new FormaPagamento("Pay Pal", 0));
            formaspAgamento.Adicionar(new FormaPagamento("Depósito em Conta", 0));

            clientes.Adicionar(new Cliente("0444444", "Ramon", "Rua", "Não tem", "041111", "caxias", "RS"));
            clientes.Adicionar(new Cliente("50000000", "Andrea", "Rua foo", "Não tem", "041111", "caxias", "RS"));
            clientes.Adicionar(new Cliente("87777777", "Luis", "Rua bar", "Não tem", "041111", "caxias", "RS"));
        }
    }
}