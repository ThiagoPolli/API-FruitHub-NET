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
        private readonly IEstadoRepository _estadoRepository;

        public CidadeService(IBaseRepository baseRepository, ICidadeRepository cidadeRepository, IMapper mapper, IEstadoRepository estadoRepository)
        {
            _baseRepository = baseRepository;
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;     
            _estadoRepository = estadoRepository;
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
        public async Task<IEnumerable<CidadeDTO>> JoinGetAllCidadeEstado(long id)
        {
            try
            {
                List<Cidade> cidades = (List<Cidade>)await _cidadeRepository.GetAllCidadeEstado(id);
                Estado estado = new Estado();
                estado = await _estadoRepository.GetEstadoId(id);
                foreach (var item in cidades)
                {
                    item.Estado = estado;
                }
                if (cidades == null) return null;

                return _mapper.Map<List<CidadeDTO>>(cidades);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CidadeDTO> GetCidadeId(long id)
        {
            try
            {
                var cidades = await _cidadeRepository.GetCidadeId(id);
                cidades.Estado = await _estadoRepository.GetEstadoId(cidades.EstadoId);

                if (cidades == null) return null;

                return _mapper.Map<CidadeDTO>(cidades);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CidadeInsertDTO> AddCIdade(CidadeInsertDTO model)
        {
            try
            {
                var cidade = _mapper.Map<Cidade>(model);
                _baseRepository.Add<Cidade>(cidade);
                bool result = await _baseRepository.SaveChangesAsync();
                if(result)
                {
                    var cidadeResult = await _cidadeRepository.GetCidadeId(cidade.Id);
                    return _mapper.Map<CidadeInsertDTO>(cidadeResult);
                }
                return null;

            }
            catch(Exception ex) 
            {
            throw new Exception(ex.Message);
            }
            
        }

        public async Task<CidadeInsertDTO> UpdateCIdade(long id, CidadeInsertDTO model)
        {
            try
            {
                var cidade = await _cidadeRepository.GetCidadeId(id);

                if (cidade == null) return null;

                model.Id = cidade.Id;
                _mapper.Map(model, cidade);

                _baseRepository.Update<Cidade>(cidade);

                if(await _baseRepository.SaveChangesAsync())
                {
                    var result = await _cidadeRepository.GetCidadeId(cidade.Id);
                    return _mapper.Map<CidadeInsertDTO>(result);
                }
                return null;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
