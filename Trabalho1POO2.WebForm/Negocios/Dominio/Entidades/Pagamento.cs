using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho1POO2.WebForm.Negocios.Dominio.Entidades
{
    public class Pagamento: Entidade
    {
        public Pagamento()
        {

        }

        public static Pagamento CriarParaTela()
        {
            return new Pagamento()
            {
                Pedido = new Pedido() { DataEmissao = DateTime.Now},
                DataCompra = DateTime.Now,
            };
        }

        public long IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public DateTime DataCompra { get; set; }
        public bool EstaPago { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataPrazoEntrega => Pedido?.PrazoEntrega ?? DateTime.MinValue;
        public FormaPagamento FormaPagamento { get; set; }
        public double TotalCompra => CalcularValorCompra();

        private double CalcularValorCompra()
        {
            if(Pedido==null) return 0;
            if (FormaPagamento == null) return Pedido.Total;

            var desconto = Pedido.Total*(FormaPagamento.Desconto/100);
            return Pedido.Total - desconto;
        }

        public override bool ValidarDados(out List<string> mensagens)
        {
            Pedido.ValidarDados(out mensagens);

            ValidarCampo(mensagens, FormaPagamento, "Forma de pagamento");

            if (TotalCompra < 50)
                mensagens.Add("Não permitir valor total do pedido menor que 50 reais");

            if (TotalCompra > 2000)
                mensagens.Add("Valor máximo para forma de pagamento cartão de crédito é R$ 2.000, 00(dois mil reais)");

            return !mensagens.Any();
        }

        public void PagamentoConfirmado()
        {
            DataPagamento = DateTime.Now;
            EstaPago = true;
        }
    }
}