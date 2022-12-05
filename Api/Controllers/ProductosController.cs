using Api.Responses;
using Application.Common.Interfaces;
using Application.Productos.Commands.CreateProducto;
using Application.Productos.Commands.DeleteProducto;
using Application.Productos.Commands.UpdateProducto;
using Application.Productos.Queries.GetAllProductos;
using Application.Productos.Queries.GetProductoById;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;

        public ProductosController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(Get))]
        public async Task<ActionResult> Get([FromQuery] GetAllProductosQuery query)
        {
            var productos = await _mediator.Send(query);
    
            var metadata = new Metadata()
            {
                TotalCount = productos.TotalCount,
                PageSize = productos.PageSize,
                CurrentPage = productos.CurrentPage,
                TotalPages = productos.TotalPages,
                HasNextPage = productos.HasNextPage,
                HasPreviousPage = productos.HasPreviousPage,
                NextPageUrl = productos.HasNextPage ? _uriService.GetAllProductos(query.PageSize, query.PageNumber + 1, query.Descendant, Url.RouteUrl(nameof(Get))).ToString() : string.Empty,
                PreviousPageUrl = productos.HasPreviousPage ? _uriService.GetAllProductos(query.PageSize, query.PageNumber - 1, query.Descendant, Url.RouteUrl(nameof(Get))).ToString() : string.Empty
            };

            var response = new ApiResponse<PagedList<ProductoDto>>(productos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var producto = await _mediator.Send(new GetProductoByIdQuery()
            {
                IdProducto = id
            });

            return Ok(producto);
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateProductoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateProductoCommand command)
        {
            await _mediator.Send(command);
            return NoContent(); 
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductoCommand()
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
