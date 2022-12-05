using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Commands.DeleteProducto
{
    public class DeleteProductoCommandValidator : AbstractValidator<DeleteProductoCommand>
    {
        public DeleteProductoCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
