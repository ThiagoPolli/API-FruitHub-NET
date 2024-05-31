using AutoMapper;
using FruitHub.Domain;
using FruitHub.Service.DTOs;

namespace FruitHub.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Categoria, CategoriaDTO>().ReverseMap();
                config.CreateMap<Produto, ProdutoDTO>().ReverseMap();
                config.CreateMap<Estado, EstadoDTO>().ReverseMap();
                config.CreateMap<Cidade, CidadeDTO>().ReverseMap();
                config.CreateMap<Cidade, CidadeInsertDTO>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
