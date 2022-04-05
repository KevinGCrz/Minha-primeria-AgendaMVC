using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o seu email de contato")]
        [EmailAddress(ErrorMessage = "Digite um email válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite sua senha")]
        public string Senha { get; set; }
    }
}
