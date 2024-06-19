using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Application.DTOs
{
    public class AlocacaoAutomaticaDTO
    {
        public int CadeiraId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
    }
}
