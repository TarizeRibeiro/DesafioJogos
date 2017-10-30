using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Proxy;
using NHibernate.Criterion;
using Entidades;
using System.Linq.Expressions;
using System.Diagnostics;
using Comuns;

namespace Repositorios.Impl
{
    public abstract class BaseRepositorio<T> : IBaseRepositorio<T> where T : BaseEntity
    {
        protected ISession Session { get; set; }

        public BaseRepositorio(ISession session)
        {
            this.Session = session;
        }

        public IQueryable<T> Query()
        {
            return this.Session.Query<T>();
        }

        public IList<T> Listar()
        {
            return this.Session.Query<T>().ToList();
        }

        public T ObterPorId(int id)
        {
            return this.Session.Query<T>().FirstOrDefault(x => x.ID == id);
        }

        public T ObterPorId(int id, bool limparSessao = false)
        {
            if (limparSessao)
            {
                Session.Clear();
            }
            var entidade = Session.Get<T>(id);
            return entidade;
        }

        public IList<T> Procurar(Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().Where(predicate).ToList();
        }

        public IList<T> Procurar(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] incluirPropriedades)
        {
            var query = Session.Query<T>().Where(predicate);

            FetchProperties(incluirPropriedades, query);

            return query.ToList();
        }
        
        public int Insert(T entidade)
        {
            var idReturn = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (IStatelessSession statelessSession = this.Session.GetSessionImplementation().Factory.OpenStatelessSession())
            using (ITransaction transaction = statelessSession.BeginTransaction())
            {

                idReturn = (int)statelessSession.Insert(entidade);
                transaction.Commit();
            }
            stopwatch.Stop();
            var time = stopwatch.Elapsed;

            return idReturn;
        }

        public void Salvar(T entidade)
        {
            var entidadeASalvar = entidade;

            entidadeASalvar = Session.Merge<T>(entidade);

            Session.Transaction.Begin();

            Session.SaveOrUpdate(entidadeASalvar);

            Session.Transaction.Commit();


        }

        public void Salvar(IList<T> lst)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (IStatelessSession statelessSession = this.Session.GetSessionImplementation().Factory.OpenStatelessSession())
            using (ITransaction transaction = statelessSession.BeginTransaction())
            {

                foreach (T l in lst)
                    statelessSession.Insert(l);
                transaction.Commit();
            }
            stopwatch.Stop();
            var time = stopwatch.Elapsed;
        }

        private static bool EstaAtualizando(T entidade)
        {
            return entidade.ID > 0;
        }

        public void Apagar(int id)
        {
            var entidade = ObterPorId(id);

            Session.Transaction.Begin();
            Session.Delete(entidade);
            Session.Transaction.Commit();
        }

        public void Apagar(T entidade)
        {
            Session.Transaction.Begin();
            Session.Delete(entidade);
            Session.Transaction.Commit();
        }

        public void Apagar(IList<T> lst)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (IStatelessSession statelessSession = this.Session.GetSessionImplementation().Factory.OpenStatelessSession())
            using (ITransaction transaction = statelessSession.BeginTransaction())
            {
                foreach (T l in lst)
                    statelessSession.Delete(l);
                transaction.Commit();
            }
            stopwatch.Stop();
            var time = stopwatch.Elapsed;
        }

        private IQueryable<T> FetchProperties(Expression<Func<T, object>>[] incluirPropriedades, IQueryable<T> query)
        {
            if (incluirPropriedades != null)
            {
                foreach (var lambdaPropriedade in incluirPropriedades)
                {
                    query = query.Fetch(lambdaPropriedade);
                }
            }

            return query;
        }

    }
}
