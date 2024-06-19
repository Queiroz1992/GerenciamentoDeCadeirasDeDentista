using AutoMapper;
using GerenDeCadeiraDeDentista.Application.DTOs;
using GerenDeCadeiraDeDentista.Application.interfaces;
using GerenDeCadeiraDeDentista.Domain.Entities;
using GerenDeCadeiraDeDentista.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Application.Services
{
    public class ServicoDeCadeiraDentista : IServicoDeCadeiraDentista
    {
        private readonly ICadeiraDentistaRepository _cadeiraDentistaRepository;
        private readonly IMapper _mapper;

        public ServicoDeCadeiraDentista(ICadeiraDentistaRepository cadeiraDentistaRepository, IMapper mapper)
        {
            _cadeiraDentistaRepository = cadeiraDentistaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CadeiraDentistaDTO>> GetAllAsync()
        {
            var cadeiraDentista = await _cadeiraDentistaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CadeiraDentistaDTO>>(cadeiraDentista);
        }

        public async Task<CadeiraDentistaDTO> GetByIdAsync(int id)
        {
            var cadeiraDentista = await _cadeiraDentistaRepository.GetByIdAsync(id);
            return _mapper.Map<CadeiraDentistaDTO>(cadeiraDentista);
        }

        public async Task CreateAsync(CadeiraDentistaDTO cadeiraDentistaDto)
        {
            var cadeiraDentista = _mapper.Map<CadeiraDentista>(cadeiraDentistaDto);
            await _cadeiraDentistaRepository.CreateAsync(cadeiraDentista);
        }

        public async Task UpdateAsync(CadeiraDentistaDTO cadeiraDentistaDto)
        {
            var cadeiraDentista = _mapper.Map<CadeiraDentista>(cadeiraDentistaDto);
            await _cadeiraDentistaRepository.UpdateAsync(cadeiraDentista);
        }

        public async Task DeleteAsync(int id)
        {
            await _cadeiraDentistaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AlocacaoAutomaticaDTO>> AlocarCadeiras(DateTime inicio, DateTime fim, int encaixe)
        {
            var cadeiraDentista = await _cadeiraDentistaRepository.GetAllAsync();
            var listaDeCadeiras = cadeiraDentista.ToList();

            if (listaDeCadeiras.Count == 0) return Enumerable.Empty<AlocacaoAutomaticaDTO>();

            var totalEncaixes = (int)(fim - inicio).TotalHours;
            var duracaoEncaixe = totalEncaixes / encaixe;

            var alocações = new List<AlocacaoAutomaticaDTO>();
            var indiceCadeira = 0;

            for (int i = 0; i < encaixe; i++)
            {
                var inicioDaDuracao = inicio.AddHours(i * duracaoEncaixe);
                var fimDaDuracao = inicioDaDuracao.AddHours(duracaoEncaixe);

                alocações.Add(new AlocacaoAutomaticaDTO
                {
                    CadeiraId = listaDeCadeiras[indiceCadeira].Id,
                    HoraInicio = inicioDaDuracao,
                    HoraFim = fimDaDuracao
                });

                indiceCadeira = (indiceCadeira + 1) % listaDeCadeiras.Count;
            }

            return alocações;
        }
    }
}
