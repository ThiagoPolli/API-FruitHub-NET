using FruitHub.Api.Models;
using System.Text.Json;

namespace FruitHub.Api.Extension
{
    public static class Pagination
    {

        public static void AddPagination(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPage)
        {
            var pagination = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPage);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(pagination, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");

        }
        /*  public static void AddPagination(this HttpResponse response,
              int currentPage, int itemsPerPage, int totalItems)
          {
              // Quantidade de produtos
              int totalProducts = totalItems;

              // Quantidade de páginas
              int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

              // Número da página atual
              int pageNumber = currentPage;

              var pagination = new
              {
                  TotalProducts = totalProducts,
                  TotalPages = totalPages,
                  CurrentPage = pageNumber
              };

              var options = new JsonSerializerOptions
              {
                  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
              };

              // Cria um objeto contendo apenas as informações de paginação
              var responseObject = new
              {
                  Pagination = pagination
              };

              // Serializa o objeto de resposta e adiciona ao cabeçalho da resposta
              response.Headers.Add("Pagination", JsonSerializer.Serialize(responseObject, options));
              response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
          }*/



    }
}
