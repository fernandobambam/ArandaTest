using Application.Interfaces;
using Application.Productos.Queries.GetAllProductos;
using Application.Productos.Queries.GetProductoById;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Productos.Handlers
{
    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, ProductoDto>
    {
        private readonly IArandaContext _arandaContext;
        private readonly IMapper _mapper;


        public GetProductoByIdHandler(IArandaContext arandaContext, IMapper mapper)
        {
            _arandaContext = arandaContext;
            _mapper = mapper; 
        }

        public Task<ProductoDto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _arandaContext.Productos.Where(x => x.IdProducto == request.IdProducto).FirstOrDefault();

            if(entity == null)
            {
                throw new NotFoundException("No se encontró ese producto");
            }

            var productoDto = _mapper.Map<ProductoDto>(entity);

            return Task.FromResult(productoDto); 
        }
    }
}
