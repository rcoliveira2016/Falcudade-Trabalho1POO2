using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Extensoes
{
    public static class ControlWebFormsExtensao
    {
        public static void CarregarItens<T>(this DropDownList combo, IEnumerable<T> list, Func<T, ListItem> map)
        {
            combo.Items.Clear();
            combo.Items.Add(new ListItem("", ""));
            foreach (var item in list)
            {
                combo.Items.Add(map(item));
            }
        }
        public static void CarregarItens<T>(this DropDownList combo, IEnumerable<T> list) where T: Entidade
        {
            combo.CarregarItens(list, x => new ListItem(x.DescricaoCombo, x.Id.ToString()));
        }
        public static bool TentarObterLong(this DropDownList combo, out long valor)
        {
            return long.TryParse(combo.SelectedItem.Value, out valor);
        }
        public static bool TentarObterLong(this TextBox txt, out long valor)
        {
            return long.TryParse(txt.Text, out valor);
        }
    }
}