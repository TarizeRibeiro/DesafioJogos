using System;
using System.Configuration;

namespace Negocios.LDAP.Configuracao.Secoes
{
    public class ActiveDirectoryGrupoElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ActiveDirectoryGrupoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var grupo = element as ActiveDirectoryGrupoElement;
            return grupo == null ? String.Empty : grupo.Nome;
        }
    }
}
