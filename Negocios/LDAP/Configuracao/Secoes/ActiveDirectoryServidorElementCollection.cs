using System;
using System.Configuration;

namespace Negocios.LDAP.Configuracao.Secoes
{
    public class ActiveDirectoryServidorElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ActiveDirectoryServidorElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var servidor = element as ActiveDirectoryServidorElement;
            return servidor == null ? String.Empty : servidor.Nome;
        }
    }
}
