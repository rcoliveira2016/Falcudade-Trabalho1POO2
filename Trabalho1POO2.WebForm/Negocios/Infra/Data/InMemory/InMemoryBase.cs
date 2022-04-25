using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;
using Trabalho1POO2.WebForm.Negocios.Repositorios;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Data.InMemory
{
    public abstract class InMemoryBase<T>: IRepositorio<T> where T: Entidade 
    {
        protected abstract IList<T> Data { get; }
        protected long idIncrement = 1;

        public virtual void Atualizar(long id, T entidade)
        {
            var index = Data.IndexOf(BuscarPorId(id));
            if (index == -1) return;
            entidade.Id = id;
            Data[index] = entidade;
        }

        public virtual void Adicionar(T entidade)
        {
            entidade.Id = idIncrement++;
            Data.Add(entidade);
        }

        public virtual void Excluir(long id)
        {
            var index = Data.IndexOf(BuscarPorId(id));
            Data.RemoveAt(index);
        }

        public virtual IEnumerable<T> BuscarTudo()
        {
            return Data;
        }

        public virtual T BuscarPorId(long id)
        {
            return Data.FirstOrDefault(x=> x.Id ==id);
        }

        public virtual IEnumerable<T> BuscarPorFiltro(Func<T, bool> filtro)
        {
            return Data.Where(filtro);
        }
    }
}