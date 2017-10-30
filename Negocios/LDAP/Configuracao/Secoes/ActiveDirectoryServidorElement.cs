using System;
using System.Configuration;

namespace Negocios.LDAP.Configuracao.Secoes
{
    public class ActiveDirectoryServidorElement : ConfigurationElement
    {
        private const string NomeServidorAttribute = "nome";

        [ConfigurationProperty(NomeServidorAttribute, IsRequired = true)]
        public string Nome
        {
            get
            {
                return this[NomeServidorAttribute].ToString();
            }
            set
            {
                this[NomeServidorAttribute] = value;
            }
        }
    }
}
