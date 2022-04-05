using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaVer1.Models
{
    public class EventoModel
    {
        public int Id { get; set; }   
        [Required(ErrorMessage = "Digite o tipo do evento")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Digite o nome do evento")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite uma breve descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite a data do evento")]
        public string Data { get; set; }
        [Required(ErrorMessage = "Digite o local do evento")]
        public string Local { get; set; }
        [Required(ErrorMessage = "Digite no mínimo o nome de 1 participante")]
        public string Participantes { get; set; }

    }
}
