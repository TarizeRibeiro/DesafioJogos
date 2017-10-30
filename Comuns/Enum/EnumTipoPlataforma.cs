using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comuns.Enum
{
    public enum EnumTipoPlataforma
    {
        [Description("Xbox")]
        XBOX = 1,

        [Description("PSP")]
        PSP = 2,

        [Description("Outros")]
        OUTROS = 3,
    }
}
