using Application.Interfaces;
using Application.Productos.Queries.GetAllProductos;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Handlers
{
    public class GetAllProductosHandler : IRequestHandler<GetAllProductosQuery, PagedList<ProductoDto>>
    {
        private readonly IArandaContext _arandaContext;
        private readonly IMapper _mapper; 
        private readonly FiltersOptions _paginationOptions; 


        public GetAllProductosHandler(IArandaContext arandaContext, IMapper mapper, IOptions<FiltersOptions> options)
        {
            _arandaContext = arandaContext;
            _mapper = mapper;
            _paginationOptions = options.Value;
        }


        public Task<PagedList<ProductoDto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            request.PageNumber = request.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : request.PageNumber; 
            request.PageSize = request.PageSize == 0 ? _paginationOptions.DefaultPageSize : request.PageSize;

            var listProducto = _arandaContext.Productos.AsQueryable();

            if(request.Nombre != null)
            {
                listProducto = listProducto.Where(x => x.Nombre == request.Nombre);
            }

            if(request.Descripcion != null)
            {
                listProducto = listProducto.Where(x => x.Descripcion == request.Descripcion);
            }

            if(request.Categoria != null)
            {
                listProducto = listProducto.Where(x => x.Categoria == request.Categoria); 
            }

            if (request.Descendant == true)
            {
                listProducto = listProducto.OrderByDescending(x => x.Nombre).ThenBy(x => x.Categoria); 
            }
            else
            {
                listProducto = listProducto.OrderBy(x => x.Nombre).ThenBy(x => x.Categoria);
            }

            var listProductoDto = _mapper.Map<IEnumerable<ProductoDto>>(listProducto.ToList());

            var pagedPost = PagedList<ProductoDto>.Create(listProductoDto, request.PageNumber, request.PageSize);

            return Task.FromResult(pagedPost);
        }
    }
}
