using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_Buffet_Williane.Models.Acesso
{
    public class CadastroUsuarioException : Exception
    {
        public IEnumerable<IdentityError> Erros { get; set; }

        public CadastroUsuarioException(IEnumerable<IdentityError> erros)
        {
            Erros = erros;
        }
    }
}
