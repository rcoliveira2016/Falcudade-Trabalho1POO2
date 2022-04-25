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

namespace Trabalho1POO2.WebForm.Paginas
{
    public partial class Pedido : Page
    {
        public IClienteRepositorio ClienteRepositorio = ServiceLocator.Get<IClienteRepositorio>();
        public IProdutoRepositorio ProdutoRepositorio = ServiceLocator.Get<IProdutoRepositorio>();
        public IFormaPagamentoRepositorio FormaPagamentoRepositorio = ServiceLocator.Get<IFormaPagamentoRepositorio>();
        public IPagamentoRepositorio PagamentoRepositorio = ServiceLocator.Get<IPagamentoRepositorio>();

        public Pagamento PagamentoModel
        {
            get
            {
                if (Session["Pagameto"] == null)
                    Session["Pagameto"] = Pagamento.CriarParaTela();

                return (Pagamento)Session["Pagameto"];
            }
            set { Session["Pagameto"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarItesnComponentes();
            }
            CarregarItensPedido();
        }

        private void CarregarItesnComponentes()
        {
            ddlCliente.CarregarItens(ClienteRepositorio.BuscarTudo());

            ddlFormapagamento.CarregarItens(FormaPagamentoRepositorio.BuscarTudo());

            ddlProduto.CarregarItens(ProdutoRepositorio.BuscarTudo());

            CarregaritemFrete();
        }

        private void CarregaritemFrete()
        {
            var tiposFrete = Enum.GetValues(typeof(eTipoFreteEntrega)).Cast<eTipoFreteEntrega>().ToList();
            ddlTipoFrete.Items.Add(new ListItem("", ""));
            foreach (var item in tiposFrete)
            {
                ddlTipoFrete.Items.Add(new ListItem(item.GetEnumDescription(), Convert.ToInt32(item).ToString()));
            }
            ddlTipoFrete.DataBind();
        }


        protected void grdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Excluir"))
            {
                var id = Convert.ToInt64(e.CommandArgument);
                ClienteRepositorio.Excluir(id);
            }
        }
        
        private void LimparCampos()
        {
            ddlCliente.SelectedIndex = 0;
            LimparCamposAdicionarItemPedido();
        }
        private void LimparCamposAdicionarItemPedido()
        {
            ddlProduto.SelectedIndex = 0;
            txtQuantidadeitens.Text = null;
        }

        private void CarregarItensPedido()
        {
            grdItensPedido.DataSource = PagamentoModel.Pedido.ItensPedidos;
            grdItensPedido.DataBind();
            CarregarTotalValores();
        }

        private void CarregarTotalValores()
        {
            spnTotaDesconto.InnerText = PagamentoModel.TotalCompra.ToString("C");
        }

        public void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlCliente.TentarObterLong(out var idCliente))
                return;

            ddlCliente.Enabled = false;
            divBtns.Visible = divPagamentos.Visible = divItensProdutos.Visible = true;
            PagamentoModel.Pedido.IdCliente = idCliente;
        }

        protected void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (!txtQuantidadeitens.TentarObterLong(out var quantidade) || !ddlProduto.TentarObterLong(out var idProduto))
                return;

            var itemPedido = new ItemPedido(quantidade, idProduto);
            PagamentoModel.Pedido.AdiconarItem(itemPedido);
            LimparCamposAdicionarItemPedido();
            CarregarItensPedido();
            (Master as SiteMaster).MensagemSucesso = "Item Adicionado com sucesso";
        }

        protected void grdItensPedido_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PagamentoModel.Pedido.RemoverItem(Convert.ToInt64(e.Values[0]));
            (Master as SiteMaster).MensagemSucesso = "Item remonvido com sucesso";
            CarregarItensPedido();
        }

        protected void ddlFormapagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlFormapagamento.TentarObterLong(out var idFormapagamento))
                return;

            PagamentoModel.FormaPagamento = FormaPagamentoRepositorio.BuscarPorId(idFormapagamento);
            PagamentoModel.Pedido.CalcularDataPrazo();
            CarregarTotalValores();
        }

        public void btnComprar_Click(object sender, EventArgs e)
        {
            if (ddlTipoFrete.TentarObterLong(out var tipoFrete))
                PagamentoModel.Pedido.Tipo = (eTipoFreteEntrega)tipoFrete;

            if(PagamentoModel.ValidarDados(out var mensagensErro))
            {
                PagamentoModel.DataCompra = DateTime.Now;
                PagamentoModel.Pedido.DataEmissao = DateTime.Now;
                PagamentoRepositorio.Adicionar(PagamentoModel);
                (Master as SiteMaster).MensagemSucesso = "Comprado com sucesso";
                divItensProdutos.Visible = divPagamentos.Visible = divBtns.Visible = false;
                cpnResumoPedido.Visible = true;
                cpnResumoPedido.CarregarDados(PagamentoModel);
                PagamentoModel = Pagamento.CriarParaTela();
            }
            else
            {
                (Master as SiteMaster).MensagemErro = mensagensErro.Aggregate((a, b) => $"{a}, {b}");
            }

        }
    }
}