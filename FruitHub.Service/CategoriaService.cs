using AutoMapper;
using FruitHub.Domain;
using FruitHub.Infra.Data.Context;
using FruitHub.Infra.Data.Models;
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
    public class CategoriaService : ICategoriaService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ICategoriaRepository _categoriaRepository;      
        private readonly IMapper _mapper;

        public CategoriaService(IBaseRepository baseRepository, ICategoriaRepository categoriaRepository,IMapper mapper)
        {
            _baseRepository = baseRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;

        }

        //BUSCAR TODAS
        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()
        {
            List<Categoria> categorias = (List<Categoria>)await _categoriaRepository.GetGetAllCategoriasAll();
            return _mapper.Map<List<CategoriaDTO>>(categorias);
        }

        //BUSCAR POR ID
        public async Task<CategoriaDTO> GetIdCategoriaAsync(long id)
        {
            try
            {
                var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
                if (categoria == null) return null;

                var result = _mapper.Map<CategoriaDTO>(categoria);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //BUSCAR POR ATIVOS
        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasByActiveAsync(bool ativo)
        {
            List<Categoria> categorias = (List<Categoria>)await _categoriaRepository.GetCategoriasActive(ativo);
            return _mapper.Map<List<CategoriaDTO>>(categorias);
        }

        //BUSCAR POR NOMES
        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasByNameAsync(string name)
        {
            try
            {


                List<Categoria> categoriaName = (List<Categoria>) await _categoriaRepository.GetCategoriasByNameAsync(name);
                if (categoriaName == null) return null;

                return _mapper.Map<List<CategoriaDTO>>(categoriaName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //BUSCAR POR NOMES QUERY PERSONALIZADA
        public async Task<IEnumerable<CategoriaDTO>> GetCategoriaPersonalizadaAsync(string name)
        {
            try
            {
                List<Categoria> categoriaName = (List<Categoria>)await _categoriaRepository.GetcategoriaPersonalizada(name);
                if (categoriaName == null) return null;

                return _mapper.Map<List<CategoriaDTO>>(categoriaName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //BUSCAR POR PAGINAS E ATIVOS
        public async Task<PageList<CategoriaDTO>> GetByPageCategoria(PageParams pageParams, bool ativo)
        {
            try
            {
                var categorias = await _categoriaRepository.GetCategoriaPage(pageParams, ativo);
                if (categorias == null) return null;

                var result = _mapper.Map<PageList<CategoriaDTO>>(categorias);

                result.CurrentPage = categorias.CurrentPage;
                result.TotalPages = categorias.TotalPages;
                result.PageSize = categorias.PageSize;
                result.TotalCount = categorias.TotalCount;
                return result;

            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }

        //ADICIONAR NOVA CATEGORIA
        public async Task<CategoriaDTO> AddCategoria(CategoriaDTO model)
        {
            try
            {
               Categoria categoria = _mapper.Map<Categoria>(model);

               _baseRepository.Add(categoria);
              if( await _baseRepository.SaveChangesAsync())
                {

                    var catecoriaReturn = await _categoriaRepository.GetCategoriaByIdAsync(categoria.Id);
                    return _mapper.Map<CategoriaDTO>(catecoriaReturn);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //ATUALIZAR UMA CATECORIA
        public async Task<CategoriaDTO> UpdateCategoria(long id, CategoriaDTO model)
        {
            try
            {
                var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);

                if (categoria == null) return null;

                model.Id = categoria.Id;
                _mapper.Map(model, categoria);

                _baseRepository.Update<Categoria>(categoria);

                if(await _baseRepository.SaveChangesAsync())
                {
                    var categoriaReturn = await _categoriaRepository.GetCategoriaByIdAsync(categoria.Id);
                    return _mapper.Map<CategoriaDTO>(categoriaReturn);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //ATIVAR OU DESATIVAR UMA CATEGORIA 
        public async Task<CategoriaDTO> UpdateActive(long id, bool active)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
            if (categoria == null) return null;
             categoria.Active = active;
            _baseRepository.Update<Categoria>(categoria);
            if (await _baseRepository.SaveChangesAsync())
            {
                var categoriaReturn = await _categoriaRepository.GetCategoriaByIdAsync(categoria.Id);
                return _mapper.Map<CategoriaDTO>(categoriaReturn);
            }

            return null;
        }

       
    }
}
