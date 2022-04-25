using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho1POO2.WebForm.Negocios.Dominio.Entidades
{
    public class Cliente : Entidade
    {
        public Cliente(string cPF, string nome, string endereco, string complemento, string cep, string cidade, string estado)
        {
            CPF = cPF;
            Nome = nome;
            Endereco = endereco;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
        public override string DescricaoCombo => $"{Nome} - {EnderecoCompleto}";
        public long Codigo { get { return Id; } set { Id = value; } }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string EnderecoCompleto => $"{Complemento}, {Endereco}, {Cidade}, {Estado}";

        public override bool ValidarDados(out List<string> mensagens)
        {
            if(!base.ValidarDados(out mensagens))
            {
                return false;
            }

            ValidarCampo(mensagens, CPF, "CPF");

            ValidarCampo(mensagens, Nome, "Nome");

            ValidarCampo(mensagens, Endereco, "Endereço");

            ValidarCampo(mensagens, Complemento, "Complemento");

            ValidarCampo(mensagens, Cep, "Cep");

            ValidarCampo(mensagens, Cidade, "Cidade");

            ValidarCampo(mensagens, Estado, "Estado");

            return !mensagens.Any();
        }

    }
}