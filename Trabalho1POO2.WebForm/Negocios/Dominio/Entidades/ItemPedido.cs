using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho1POO2.WebForm.Negocios.Infra.Ioc;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public ItemPedido(long quantidade, long idProdudo)
        {
            Quantidade = quantidade;
            IdProdudo = idProdudo;
            SetarCalculo();
        }

        public long Quantidade { get; private set; }
        public long IdProdudo { get; private set; }
        public Produto Produto  => ServiceLocator.Get<IProdutoRepositorio>().BuscarPorId(IdProdudo);
        public long NumeroProduto => Id;
        public double ValorUnitario => Produto?.PrecoVenda??0;
        public string Descricao => Produto?.Descricao;
        public double Total { get; set; }

        public void SetarCalculo()
        {
            Total = Quantidade * ValorUnitario;
        }
    }
}