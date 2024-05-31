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
    public class EstadoService : IEstadoService
    {
        private IBaseRepository _baseRepository;
        private readonly IEstadoRepository _repository;
        private readonly IMapper _mapper;

        public EstadoService(IBaseRepository baseRepository, IEstadoRepository repository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _repository = repository;
            _mapper = mapper;
        }

        //BUSCAR TODOS
        public async Task<IEnumerable<EstadoDTO>> GetAllEstadoAsyc()
        {
            List<Estado> estados = (List<Estado>)await _repository.GetAllEstado();
            return _mapper.Map<List<EstadoDTO>>(estados);
        }

        //BUSCAR POR ID
        public async Task<EstadoDTO> GetEstadoIdAsync(long id)
        {
            try
            {
                var estado = await _repository.GetEstadoId(id);
                if (estado == null) { return null; }

                return _mapper.Map<EstadoDTO>(estado);               

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstadoDTO> AddEstadoe(EstadoDTO estadoDTO)
        {
            try
            {
                Estado estado = _mapper.Map<Estado>(estadoDTO);
                _baseRepository.Add(estado);
                if( await _baseRepository.SaveChangesAsync() )
                {
                    var result = await _repository.GetEstadoId(estado.Id);
                    return _mapper.Map<EstadoDTO>(result);
                }
                return null;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
