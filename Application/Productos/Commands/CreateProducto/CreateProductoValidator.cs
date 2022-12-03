using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Commands.CreateProducto
{
    public class CreateProductoValidator : AbstractValidator<CreateProductoCommand>
    {
        public CreateProductoValidator()
        {
            RuleFor(producto => producto.Nombre)
                .NotNull()
                .MaximumLength(100);

            RuleFor(producto => producto.Descripcion)
                .MaximumLength(200);

            RuleFor(producto => producto.Categoria)
                .MaximumLength(100);
        }
    }
}
