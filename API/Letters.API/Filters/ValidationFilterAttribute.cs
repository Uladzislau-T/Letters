using Letters.Domain.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Letters.API.Filters
{
  /// <summary>
  /// A filter that handles errors when they occur.
  /// </summary>
  public class ValidationFilterAttribute : IActionFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {        
        var messages = new List<string>();

        messages.AddRange(context.ModelState.Values
                     .SelectMany(x => x.Errors)
                     .Select(x => !string.IsNullOrWhiteSpace(x.ErrorMessage) ? x.ErrorMessage : x.Exception.Message)); 
        
        var responseObj = new ErrorDetails()
        {
            StatusCode = "Bad Request",
            Errors = messages                    
        };

        context.Result = new JsonResult(responseObj)
        {
            StatusCode = 400
        };
      }
    }
    public void OnActionExecuted(ActionExecutedContext context) {}
  }
}