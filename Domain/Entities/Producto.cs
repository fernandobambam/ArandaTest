using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public string? Imagen { get; set; }
}
