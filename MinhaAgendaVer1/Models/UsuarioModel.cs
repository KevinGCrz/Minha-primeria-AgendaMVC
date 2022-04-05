using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o seu nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o seu email de contato")]
        [EmailAddress(ErrorMessage = "Digite um email válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite uma senha para seu perfil")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite sua data de nascimento")]
        public string DataNascimento { get; set; }
        [Required(ErrorMessage = "Digite seu sexo")]
        public string Sexo { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
