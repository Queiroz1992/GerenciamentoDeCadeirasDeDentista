﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Application.DTOs
{
    public class CadeiraDentistaDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public string InformacaoAdicional { get; set; }
    }
}
