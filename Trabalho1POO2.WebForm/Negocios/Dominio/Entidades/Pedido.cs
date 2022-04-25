using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Trabalho1POO2.WebForm.Negocios.Infra.Ioc;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        private List<ItemPedido> _itensPedidos;

        public Pedido()
        {
            _itensPedidos = new List<ItemPedido>();
        }
        public long IdCliente { get; set; }
        public Cliente Cliente => ServiceLocator.Get<IClienteRepositorio>().BuscarPorId(IdCliente);
        public IReadOnlyCollection<ItemPedido> ItensPedidos => _itensPedidos.AsReadOnly();
        public DateTime DataEmissao { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public eTipoFreteEntrega Tipo { get; set; }
        public double Total => ItensPedidos.Sum(x => x.Total);

        public void CalcularDataPrazo()
        {
            PrazoEntrega = DataEmissao.AddDays(20);
        }

        public void RemoverItem(long id)
        {
            var itemRemove = _itensPedidos.FirstOrDefault(x=> x.Id==id);
            if (itemRemove != null)
                _itensPedidos.Remove(itemRemove);
        }

        public void AdiconarItem(ItemPedido item)
        {
            item.Id = _itensPedidos.Any()? _itensPedidos.Max(x => x.Id)+1 : 1;
            _itensPedidos.Add(item);
        }

        public override bool ValidarDados(out List<string> mensagens)
        {
            mensagens = new List<string>();
            ValidarCampo(mensagens, IdCliente, "Cliente");

            if (!ItensPedidos.Any())
                mensagens.Add("Adiconar pelo menos 1 produto");

            ValidarCampo(mensagens, (long)Tipo, "Tipo de frete");


            return !mensagens.Any();
        }
    }

    public enum eTipoFreteEntrega
    {
        [Description("Transportadora")]
        Transportadora = 1,
        [Description("Correios")]
        Correios = 2,
        [Description("Aéreo")]
        Aereo = 3,
    }
}