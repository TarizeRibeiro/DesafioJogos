using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Negocios.Impl
{
    public abstract class BaseNegocio<T> : IBaseNegocio<T> where T : BaseEntity
    {
        public BaseNegocio()
        {
        }

        public BaseNegocio(IBaseRepositorio<T> repositorio)
        {
            Repositorio = repositorio;
        }

        public IBaseRepositorio<T> Repositorio { get; set; }

        public IList<T> Listar()
        {
            return Repositorio.Listar();
        }

        public T ObterPorId(int id)
        {
            return Repositorio.ObterPorId(id);
        }

        public T ObterPorId(int id, bool limparSessao = false)
        {
            return Repositorio.ObterPorId(id, limparSessao);
        }

        public IList<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Repositorio.Procurar(predicate);
        }

        public IList<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] incluirPropriedades)
        {
            return Repositorio.Procurar(predicate, incluirPropriedades);
        }

        public int Insert(T entidade)
        {
            return Repositorio.Insert(entidade);
        }

        public void Salvar(T entidade)
        {
            Repositorio.Salvar(entidade);
        }

        public void Salvar(IList<T> lst)
        {
            Repositorio.Salvar(lst);
        }

        public void Excluir(int id)
        {
            Repositorio.Apagar(id);
        }

        public void Excluir(T entidade)
        {
            Repositorio.Apagar(entidade);
        }

        public void Excluir(IList<T> lst)
        {
            Repositorio.Apagar(lst);
        }

    }
}
