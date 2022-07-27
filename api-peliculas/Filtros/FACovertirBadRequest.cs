using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;

namespace api_peliculas.Filtros
{
    public class FACovertirBadRequest : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            return;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var convertirResultado = context.Result as IStatusCodeActionResult;
            if(convertirResultado == null)
            {
                return;
            }
            var codigoEstatus = convertirResultado.StatusCode;
            if(codigoEstatus == 400)
            {
                var res = new List<string>();
                var resultado=context.Result as BadRequestObjectResult;
                if(resultado.Value is string)
                {
                    res.Add(resultado.Value.ToString());
                }
                else
                {
                    foreach(var llave in context.ModelState.Keys)
                    {
                        foreach (var error in context.ModelState[llave].Errors)
                        {
                            res.Add($"{llave}:{error.ErrorMessage}");
                        }
                    }
                }
                context.Result = new BadRequestObjectResult(res);

            }
        }


    }
}
