﻿using FruitHub.Api.Models;
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
    }
}
