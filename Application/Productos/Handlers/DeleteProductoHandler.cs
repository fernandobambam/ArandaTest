using Application.Interfaces;
using Application.Productos.Commands.DeleteProducto;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Handlers
{
    public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand>
    {
        private readonly IArandaContext _arandaContext; 

        public DeleteProductoHandler(IArandaContext arandaContext)
        {
            _arandaContext = arandaContext;
        }

        public async Task<Unit> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _arandaContext.Productos.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException("No existe ese producto");
            }

            _arandaContext.Productos.Remove(entity);

            await _arandaContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
