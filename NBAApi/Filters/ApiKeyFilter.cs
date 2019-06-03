using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Filters
{
    public class ApiKeyFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
                var apiKey = context.HttpContext.Request.Headers["API-KEY"];
                if (apiKey != "1111")
                {
                    context.Result = new StatusCodeResult(401);
                }
            
        }
    }
}

