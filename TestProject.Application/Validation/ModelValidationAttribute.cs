using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using TestProject.Application.DTOs;
using TestProject.Domain.Models;

namespace TestProject.Application.Validation
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrors = context.ModelState.Select(model => new
                {
                    key = model.Key,
                    Error = model.Value.Errors.Select(error => new 
                    {
                        ValidationType = error.ErrorMessage,
                        ValidationKey = $"{model.Key}_{error.ErrorMessage}"
                    })
                });

                context.Result = new BadRequestObjectResult(new ResponseDTO
                {
                    StatusCode = DomainStatusCodes.ValidationError,
                    Result = validationErrors
                });
            }
        }
    }
}