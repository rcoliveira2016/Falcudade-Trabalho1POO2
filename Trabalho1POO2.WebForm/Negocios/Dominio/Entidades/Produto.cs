using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho1POO2.WebForm.Negocios.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public Produto(string descricao, double precoVenda)
        {
            Descricao = descricao;
            PrecoVenda = precoVenda;
        }

        public string Descricao { get; set; }
        public override string DescricaoCombo => $"{Descricao} - {PrecoVenda.ToString("C")}";
        public double PrecoVenda { get; set; }
        public override bool ValidarDados(out List<string> mensagens)
        {
            mensagens = new List<string>();
            ValidarCampo(mensagens, PrecoVenda, "Preço");

            ValidarCampo(mensagens, Descricao, "Descrição");


            return !mensagens.Any();
        }
    }
}