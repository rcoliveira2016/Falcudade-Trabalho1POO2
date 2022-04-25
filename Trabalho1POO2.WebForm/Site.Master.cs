using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabalho1POO2.WebForm
{
    public partial class SiteMaster : MasterPage
    {
        private string _mensagemErro;
        public string MensagemErro
        {
            get {
                ControlarExibicaoMensagens();
                return _mensagemErro; 
            }
            set {
                _mensagemErro = value; 
                ControlarExibicaoMensagens();
            }
        }

        private string _mensagemSucesso;
        public string MensagemSucesso { 
            get {
                ControlarExibicaoMensagens();
                return _mensagemSucesso;  
            } 
            set {
                _mensagemSucesso = value; 
                ControlarExibicaoMensagens();
            }
        }

        private void ControlarExibicaoMensagens()
        {
            divAlertaSucesso.Visible = !string.IsNullOrEmpty(_mensagemSucesso);
            divAlertaDanger.Visible = !string.IsNullOrEmpty(_mensagemErro);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlarExibicaoMensagens();
        }
        protected void Page_LoadCompleted(object sender, EventArgs e)
        {
            ControlarExibicaoMensagens();
        }
    }
}