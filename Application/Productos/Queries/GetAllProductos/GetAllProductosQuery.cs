using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Queries.GetAllProductos
{
    public class GetAllProductosQuery : IRequest<PagedList<ProductoDto>>
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public bool Descendant { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
