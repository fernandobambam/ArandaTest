using Application.Interfaces;
using Application.Productos.Queries;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Handlers
{
    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, Producto>
    {
        private readonly IArandaContext _arandaContext; 


        public GetProductoByIdHandler(IArandaContext arandaContext)
        {
            _arandaContext = arandaContext; 
        }

        public Task<Producto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _arandaContext.Productos.Where(x => x.IdProducto == request.IdProducto).FirstOrDefault();

            if(entity == null)
            {
                throw new BusinessException("No se encontró ese producto");
            }

            return Task.FromResult(entity); 
        }
    }
}
