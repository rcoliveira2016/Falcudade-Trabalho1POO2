using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho1POO2.WebForm.Negocios.Dominio.Entidades
{
    public class FormaPagamento : Entidade
    {
        public FormaPagamento(string descricao, double desconto)
        {
            Descricao = descricao;
            Desconto = desconto;
        }

        public string Descricao { get; set; }
        public override string DescricaoCombo => $"{Descricao} (-{Desconto}%)";
        public long Codigo { get { return Id; } set { Id = value; } }
        public double Desconto { get; set; }
    }
}