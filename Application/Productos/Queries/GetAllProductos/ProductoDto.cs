using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Queries.GetAllProductos
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? Categoria { get; set; }

        public string? Imagen { get; set; }

    }
}
