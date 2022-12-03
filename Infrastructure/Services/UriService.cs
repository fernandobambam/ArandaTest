using Application.Common.Interfaces;
using Application.Productos.Queries;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllProductos(int PageSize, int PageNumber, bool Order,string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";

            var modifiedUri = QueryHelpers.AddQueryString(baseUrl, "PageSize", PageSize.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "PageNumber", PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "Descendant", Order.ToString());

            return new Uri(modifiedUri);
        }

    }
}
