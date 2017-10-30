using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IBaseRepositorio<T> where T : BaseEntity
    {
        T ObterPorId(int id);
        
        IQueryable<T> Query();
        
        IList<T> Listar();
        
        int Insert(T entidade);
        
        T ObterPorId(int id, bool limparSessao = false);
        
        IList<T> Procurar(Expression<Func<T, bool>> predicate);
        
        IList<T> Procurar(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] incluirPropriedades);
        
        void Salvar(T entidade);
        
        void Salvar(IList<T> lst);
        
        void Apagar(int id);
        
        void Apagar(T entidade);
        
        void Apagar(IList<T> lst);
    }
}
