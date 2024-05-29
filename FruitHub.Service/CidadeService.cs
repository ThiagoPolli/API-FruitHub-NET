using AutoMapper;
using FruitHub.Domain;
using FruitHub.Infra.Data.Repository;
using FruitHub.Service.DTOs;
using FruitHub.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Service
{
    public class CidadeService : ICidadeService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public CidadeService(IBaseRepository baseRepository, ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;            
        }

        public async Task<IEnumerable<CidadeDTO>> GetAllCidade()
        {
            List<Cidade> cidades = (List<Cidade>)await _cidadeRepository.GetAllCidade();
            return _mapper.Map<List<CidadeDTO>>(cidades);
        }

        public async Task<IEnumerable<CidadeDTO>> GetAllCidadeEstado(long id)
        {
            try
            {
                List<Cidade> cidades = (List<Cidade>)await _cidadeRepository.GetAllCidadeEstado(id);
                if (cidades == null) return null;

                return _mapper.Map<List<CidadeDTO>>(cidades);


            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CidadeDTO> GetAllCidadeIdo(long id)
        {
            try
            {
                var cidades = await _cidadeRepository.GetAllCidadeId(id);
                if (cidades == null) return null;

                return _mapper.Map<CidadeDTO>(cidades);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
