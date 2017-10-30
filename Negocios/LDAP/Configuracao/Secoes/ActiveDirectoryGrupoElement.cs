
using System.Configuration;
namespace Negocios.LDAP.Configuracao.Secoes
{
    public class ActiveDirectoryGrupoElement : ConfigurationElement
    {
        private const string NomeGrupoAttribute = "nome";

        [ConfigurationProperty(NomeGrupoAttribute, IsRequired = true)]
        public string Nome
        {
            get
            {
                return this[NomeGrupoAttribute].ToString();
            }
            set
            {
                this[NomeGrupoAttribute] = value;
            }
        }
    }
}
