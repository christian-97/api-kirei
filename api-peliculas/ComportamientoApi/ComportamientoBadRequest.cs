using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_peliculas.ComportamentoApi
{
    public static class ComportamientoBadRequest
    {
        public static void Convertir(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = actionContext =>
                 {
                     var res = new List<string>();
                     foreach (var llave in actionContext.ModelState.Keys)
                     {
                         foreach (var error in actionContext.ModelState[llave].Errors)
                         {
                             res.Add($"{llave}:{error.ErrorMessage}");
                         }
                     }
                     return new BadRequestObjectResult(res);
                 };
        }
    }
}
