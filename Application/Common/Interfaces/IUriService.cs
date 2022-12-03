using Application.Productos.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUriService
    {
        Uri GetAllProductos(int PageSize, int PageNumber, bool Order, string actionUrl);
    }
}
