using Application.Interfaces;
using Application.Productos.Commands.UpdateProducto;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Handlers
{
    public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand>
    {
        private readonly IArandaContext _arandaContext;

        public UpdateProductoHandler(IArandaContext arandaContext)
        {
            _arandaContext = arandaContext;
        }

        public async Task<Unit> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var entity = _arandaContext.Productos.Where(x => x.IdProducto == request.IdProducto)
                                                        .FirstOrDefault();

            if (entity == null)
            {
                throw new NotFoundException("No existe producto con ese Id");
            }

            entity.Nombre = request.Nombre;
            entity.Descripcion = request.Descripcion;
            entity.Categoria = request.Categoria;
            entity.Imagen = request.Imagen; 

            _arandaContext.Productos.Update(entity);

            await _arandaContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
