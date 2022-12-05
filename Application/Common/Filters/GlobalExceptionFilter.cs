using Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(NotFoundException))
            {
                var exception = (NotFoundException)context.Exception;
                var validation = new
                {
                    Status = 404,
                    Title = "Not Found",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.ExceptionHandled = true; 
            }
          
            else if (context.Exception.GetType() == typeof(SqlException))
            {
                var exception = (SqlException)context.Exception;
                var validation = new
                {
                    Status = 500,
                    Title = "Internal Server Error",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.ExceptionHandled = true;
            }
        }
    }
}
