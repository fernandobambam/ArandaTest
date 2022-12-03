using Application.Interfaces;
using Application.Productos.Commands.CreateProducto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Handlers
{
    public class CreateProductoHandler : IRequestHandler<CreateProductoCommand>
    {
        private readonly IArandaContext _arandaContext; 

        public CreateProductoHandler(IArandaContext arandaContext)
        {
            _arandaContext = arandaContext;
        }

        public async Task<Unit> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var entity = new Producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Categoria = request.Categoria,
                Imagen = request.Imagen   
            };

            await _arandaContext.Productos.AddAsync(entity);

            await _arandaContext.SaveChangesAsync(cancellationToken); 
           
            return Unit.Value;
        }
    }
}
