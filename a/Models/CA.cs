using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace a.Models
{
    public class CA
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }
        
    }
}
