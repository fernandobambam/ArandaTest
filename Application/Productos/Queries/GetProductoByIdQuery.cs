using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Queries
{
    public class GetProductoByIdQuery : IRequest<Producto>
    {
        public int IdProducto { get; set; }
    }
}
