using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Domain.Entities
{
    public class CadeiraDentista
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(300, ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
        public string Descricao { get; set; }
        public string InformacaoAdicional { get; set; }
    }
}
