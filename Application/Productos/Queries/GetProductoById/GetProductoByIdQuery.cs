using Application.Productos.Queries.GetAllProductos;
using MediatR;

namespace Application.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQuery : IRequest<ProductoDto>
    {
        public int IdProducto { get; set; }
    }
}
