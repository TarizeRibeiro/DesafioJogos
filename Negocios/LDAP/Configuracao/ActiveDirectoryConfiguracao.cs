#region Assembly System.Configuration.dll, v4.0.0.0
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Configuration.dll
#endregion
using System.Configuration;
using Negocios.LDAP.Configuracao.Secoes;

namespace Negocios.LDAP.Configuracao
{
    public static class ActiveDirectoryConfiguracao
    {
        private const string SecaoConfiguracaoActiveDirectory = "activeDirectoryConfiguracao";

        public static ActiveDirectoryConfigurationSection ConfiguracoesActiveDirectory()
        {
            return ConfigurationManager.GetSection(SecaoConfiguracaoActiveDirectory) as ActiveDirectoryConfigurationSection;
        }
    }
}