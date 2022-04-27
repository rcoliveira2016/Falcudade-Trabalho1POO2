using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Infra.Ioc;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Paginas
{
    public partial class Clientes : Page
    {
        public IClienteRepositorio ClienteRepositorio = ServiceLocator.Get<IClienteRepositorio>();

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            grdDados.DataSource = ClienteRepositorio.BuscarTudo().ToList();
            grdDados.DataBind();
        }

        protected void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var novoCliente = ObterNovoCliente();
                if (!novoCliente.ValidarDados(out var msg))
                {
                    (Master as SiteMaster).MensagemErro = $"{msg.Aggregate((a,b)=> $"{a}, {b}")}";
                    return;
                }
                ClienteRepositorio.Adicionar(novoCliente);
                LimparCampos();
                CarregarListagem();
                (Master as SiteMaster).MensagemSucesso = "Cliente Cadastrado Com sucesso";
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).MensagemErro = $"{exc.Message}";
            }
        }

        
        private Cliente ObterNovoCliente()
        {
            return new Cliente(txtCPF.Text, txtNome.Text, txtEndereco.Text, txtComplemento.Text, txtCep.Text, txtCidade.Text, txtEstado.Text);
        }

        private void LimparCampos()
        {
            txtCep.Text = 
                txtCidade.Text = 
                txtComplemento.Text = 
                txtCPF.Text = 
                txtEndereco.Text = 
                txtEstado.Text = 
                txtNome.Text = string.Empty;
        }

        protected void grdDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var codigo = Convert.ToInt64(e.Values[0]);
                ClienteRepositorio.Excluir(codigo);
                (Master as SiteMaster).MensagemSucesso = "Cliente excluido com sucesso";
                CarregarListagem();
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).MensagemErro = $"{exc.Message}";
            }            
        }
    }
}