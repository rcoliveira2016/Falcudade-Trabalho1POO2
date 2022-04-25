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
    public partial class RelatorioPedidos : Page
    {
        public IPagamentoRepositorio PagamentoRepositorio = ServiceLocator.Get<IPagamentoRepositorio>();
        public Pagamento PagamentoModel
        {
            get
            {
                return (Pagamento)Session["Pagameto__"];
            }
            set { Session["Pagameto__"] = value; }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            cpnResumoPedido.Visible = false;
            if (!txtNumeroPedido.TentarObterLong(out var numeroPedido))
                return;

            var pagamento = PagamentoRepositorio.BuscarPorId(numeroPedido);
            if (pagamento == null)
            {
                (Master as SiteMaster).MensagemErro = $"O pedido '{numeroPedido}' não foi encontrado";
                return;
            }

            PagamentoModel = pagamento;
            cpnResumoPedido.Visible = true;
            cpnResumoPedido.CarregarDados(PagamentoModel);
        }
    }
}