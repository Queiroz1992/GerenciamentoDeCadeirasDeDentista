using AutoMapper;
using GerenDeCadeiraDeDentista.Application.DTOs;
using GerenDeCadeiraDeDentista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Application.Mappings
{
    public class MapeamentoDePerfil : Profile
    {
        public MapeamentoDePerfil()
        {
            CreateMap<CadeiraDentista, CadeiraDentistaDTO>().ReverseMap();
        }
    }
}
