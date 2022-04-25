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
    public partial class Produtos : System.Web.UI.Page
    {
        public IProdutoRepositorio ProdutoRepositorio = ServiceLocator.Get<IProdutoRepositorio>();
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListagem();
        }
        public void LimparCampos()
        {
            txtDescricao.Text = "";
            txtPreco.Text = "0";
        }

        private void CarregarListagem()
        {
            grdDados.DataSource = ProdutoRepositorio.BuscarTudo().ToList();
            grdDados.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!txtPreco.TentarObterLong(out var preco))
                return;

            var produto = new Produto(txtDescricao.Text, preco);
            if(produto.ValidarDados(out var mgs))
            {
                (Master as SiteMaster).MensagemSucesso = "Comprado com sucesso";
                ProdutoRepositorio.Adicionar(produto);
                LimparCampos();
                CarregarListagem();
            }
            else
            {
                (Master as SiteMaster).MensagemErro = mgs.Aggregate((a, b) => $"{a}, {b}");
            }

        }
    }
}