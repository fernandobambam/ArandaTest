using Application.Productos.Queries.GetAllProductos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();
        }
    }
}
