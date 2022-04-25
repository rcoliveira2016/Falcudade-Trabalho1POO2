using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Data.InMemory
{
    public class ClienteInMemory : InMemoryBase<Cliente>, IClienteRepositorio
    {
        private static readonly List<Cliente> _data = new List<Cliente>();
        protected override IList<Cliente> Data => _data;
    }
}