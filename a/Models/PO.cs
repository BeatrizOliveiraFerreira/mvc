using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace a.Models
{
    public class PO
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Range(1, 10, ErrorMessage = "Valor fora da faixa")]
        public int Quantidade { get; set; }
        public int CAId { get; set; }
        public CA CA { get; set; }
    }
}
