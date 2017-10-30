using Autofac;
using Autofac.Integration.Mvc;
using Bootstrapper.LogModule;
using Entidades;
using Entidades.Mapeamentos;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net;
using Negocios.Impl;
using NHibernate;
using Repositorios.Impl;
using System;


namespace Bootstrapper
{
    public class Bootstrapper
    {
        public static ContainerBuilder ObterContainer()
        {
            try
            {
                var builder = new ContainerBuilder();

                builder.Register(x => GetSessionFactory("thread_static", "ConexaoPadrao"))
                    .SingleInstance();

                builder.Register(x =>
                {
                    var session = x.Resolve<ISessionFactory>().OpenSession();
                    session.FlushMode = FlushMode.Commit;
                    return session;
                }).InstancePerHttpRequest().OnRelease(x => x.Dispose());

                var entidades = typeof(BaseEntity).Assembly;
                builder.RegisterAssemblyTypes(entidades)
                    .Where(t => t.BaseType == typeof(BaseEntity))
                    .AsSelf();

                var repositorioSQLSERVER = typeof(BaseRepositorio<>).Assembly;
                builder.RegisterAssemblyTypes(repositorioSQLSERVER)
                    .Where(t => t.Name.EndsWith("Repositorio"))
                    .AsImplementedInterfaces()
                    .PropertiesAutowired();

                var servicos = typeof(BaseNegocio<>).Assembly;
                builder.RegisterAssemblyTypes(servicos)
                    .Where(t => t.Name.EndsWith("Negocio"))
                    .AsImplementedInterfaces()
                    .PropertiesAutowired();
                                
                builder.RegisterModule(new LoggingModule());
                builder.RegisterInstance(LogManager.GetLogger("DesafioJogos"))
                    .As<ILog>();

                return builder;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ISessionFactory GetSessionFactory(string currentSessionContextClass, string connectionStringKey)
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ShowSql()
                    .ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKey)))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(AmigoMap).Assembly))
                    .ExposeConfiguration(x => x.SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, currentSessionContextClass))
                    .Cache(x => x.UseQueryCache())
                    .BuildSessionFactory();
        }
    }
}
