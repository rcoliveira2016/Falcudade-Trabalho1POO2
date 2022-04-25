using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Infra.Extensoes;
using Trabalho1POO2.WebForm.Negocios.Infra.Ioc;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Componentes
{
    public partial class ResumoPedido : System.Web.UI.UserControl
    {
        public IPagamentoRepositorio PagamentoRepositorio = ServiceLocator.Get<IPagamentoRepositorio>();

        private Pagamento PagamentoModel
        {
            get
            {
                return (Pagamento)Session["ResumoPedido"];
            }
            set { Session["ResumoPedido"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarCampos();
        }

        public void CarregarDados(Pagamento pagamentoModel)
        {
            PagamentoModel = pagamentoModel;
            CarregarCampos();            
        }
        private void CarregarCampos()
        {
            if (PagamentoModel == null) return;
            divPagamento.Visible = !PagamentoModel.EstaPago;
            CarregarItensPedido();

            spnDataCompra.InnerText = PagamentoModel.DataCompra.ToString();
            spnEnderecoEntrada.InnerText = PagamentoModel.Pedido.Cliente.EnderecoCompleto;

            spnEstaPago.InnerText = PagamentoModel.EstaPago ? "Sim" : "não";
            dtDataPagamento.Visible = ddDataPagamento.Visible = PagamentoModel.EstaPago;
            spnDataPagamento.InnerText = PagamentoModel.DataPagamento.ToString();

            spnFormaPagamento.InnerText = PagamentoModel.FormaPagamento.Descricao;
            spnFrete.InnerText = PagamentoModel.Pedido.Tipo.GetEnumDescription();
            spnNomeCliente.InnerText = PagamentoModel.Pedido.Cliente.Nome;
            spnNumero.InnerText = PagamentoModel.Id.ToString();
            spnPrevisaoEntrega.InnerText = PagamentoModel.DataPrazoEntrega.ToString();
            spnValorTotal.InnerText = PagamentoModel.TotalCompra.ToString("C");
        }
        private void CarregarItensPedido()
        {
            grdItensPedidoResumo.DataSource = PagamentoModel.Pedido.ItensPedidos;
            grdItensPedidoResumo.DataBind();
        }

        protected void btnConfrimaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoModel.PagamentoConfirmado();
                PagamentoRepositorio.Atualizar(PagamentoModel.Id, PagamentoModel);
                CarregarCampos();
                (Page.Master as SiteMaster).MensagemSucesso = "Pago Com sucesso";
            }
            catch (Exception)
            {
                (Page.Master as SiteMaster).MensagemErro = "Erro ao pagar";
            }
        }
    }
}