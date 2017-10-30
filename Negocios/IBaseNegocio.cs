using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public interface IBaseNegocio<T> where T : BaseEntity
    {
        /// <summary>
        /// Recupera o objeto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        T ObterPorId(int id);

        /// <summary>
        /// Recupera a lista da entidade corrente
        /// </summary>
        /// <returns>IList<T></returns>
        IList<T> Listar();

        /// <summary>
        /// Metoo que realia a inclusão e um objeto no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        int Insert(T entidade);

        /// <summary>
        /// Recupera um objeto do banco de dados pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="limparSessao">Limpa a sessão para que não pegue o objeto do proxy</param>
        /// <returns></returns>
        T ObterPorId(int id, bool limparSessao = false);

        /// <summary>
        /// Procura registros no banco de dados
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IList<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Procura registros no banco de dados
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="incluirPropriedades"></param>
        /// <returns></returns>
        IList<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] incluirPropriedades);

        /// <summary>
        /// Persiste um objeto no SGBD
        /// </summary>
        /// <param name="entidade"></param>
        void Salvar(T entidade);

        /// <summary>
        /// Persiste uma lista de objeto no SGBD
        /// </summary>
        /// <param name="lst"></param>
        void Salvar(IList<T> lst);

        /// <summary>
        /// Exclui um objeto do SGBD pelo seu id
        /// </summary>
        /// <param name="id"></param>
        void Excluir(int id);

        /// <summary>
        /// Exclui um objeto do SGBD
        /// </summary>
        /// <param name="entidade"></param>
        void Excluir(T entidade);

        /// <summary>
        /// Exclui uma lista de objeto do SGBD
        /// </summary>
        /// <param name="lst"></param>
        void Excluir(IList<T> lst);
    }
}
