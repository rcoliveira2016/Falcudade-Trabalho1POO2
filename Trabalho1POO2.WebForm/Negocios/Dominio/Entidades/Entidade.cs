using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho1POO2.WebForm.Negocios.Dominio.Entidades
{
    public abstract class Entidade
    {
        public long Id { get; set; }
        public virtual bool ValidarDados(out List<string> mensagens)
        {
            mensagens = new List<string>();
            return true;
        }
        public void ValidarCampo(List<string> mensagens, string campo, string nomeCampo)
        {
            if (string.IsNullOrEmpty(campo))
                mensagens.Add(string.Format(MensagemCampoVazio, nomeCampo));
        }

        public void ValidarCampo(List<string> mensagens, long campo, string nomeCampo)
        {
            if (campo==0)
                mensagens.Add(string.Format(MensagemCampoVazio, nomeCampo));
        }

        public void ValidarCampo(List<string> mensagens, object campo, string nomeCampo)
        {
            if (campo == null)
                mensagens.Add(string.Format(MensagemCampoVazio, nomeCampo));
        }

        public virtual string DescricaoCombo => string.Empty;

        public string MensagemCampoVazio => "Campo '{0}' está vazio";
    }
}