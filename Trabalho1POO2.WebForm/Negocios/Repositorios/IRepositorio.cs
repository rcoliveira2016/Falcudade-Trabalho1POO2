using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1POO2.WebForm.Negocios.Dominio.Entidades;

namespace Trabalho1POO2.WebForm.Negocios.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Atualizar(long id, T entidade);
        void Adicionar(T entidade);
        void Excluir(long id);
        IEnumerable<T> BuscarTudo();
        T BuscarPorId(long id);
        IEnumerable<T> BuscarPorFiltro(Func<T, bool> filtro);
    }
}
