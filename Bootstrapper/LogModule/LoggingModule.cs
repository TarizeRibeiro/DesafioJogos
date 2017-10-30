using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;
using log4net;

namespace Bootstrapper.LogModule
{
    public class LoggingModule : Autofac.Module
    {
        private static void InjectLoggerProperties(object instance)
        {
            var instanceType = instance.GetType();
            
            var properties = instanceType
              .GetProperties(BindingFlags.Public | BindingFlags.Instance)
              .Where(p => p.PropertyType == typeof(ILog) && p.CanWrite && p.GetIndexParameters().Length == 0);
            
            foreach (var propToSet in properties)
            {
                propToSet.SetValue(instance, LogManager.GetLogger(instanceType), null);
            }
        }

        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Activator.LimitType;
            e.Parameters = e.Parameters.Union(
              new[] { new ResolvedParameter((p, i) => p.ParameterType == typeof(ILog), (p, i) => LogManager.GetLogger(t)), });
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += OnComponentPreparing;
            
            registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
        }
    }
}

