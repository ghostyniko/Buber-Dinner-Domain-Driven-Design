using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DomainErrors = BuberDinner.Domain.Common.Errors.Errors;

namespace BuberDinner.Api.Controllers
{
    public static class ControllerExtensions
    {
        public static IActionResult Problem(this ControllerBase controllerBase,List<Error> errors)
        {

             if (errors.Count is 0)
            {
                return controllerBase.Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return controllerBase.ValidationProblem(errors);
            }
            
            controllerBase.HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            var firstError = errors[0];
            return controllerBase.Problem(firstError);
        } 

         private static IActionResult Problem(this ControllerBase controllerBase,Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => error == DomainErrors.Authentication.InvalidCredentials ?
                                        StatusCodes.Status401Unauthorized :
                                        StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return controllerBase.Problem(title: error.Description, statusCode: statusCode);
        }

        private static IActionResult ValidationProblem(this ControllerBase controllerBase, List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description);
            }
            return controllerBase.ValidationProblem(modelStateDictionary);
        }

         public static IActionResult ProblemOrResult<ServiceResult,Response>(
            this ControllerBase controllerBase,
            ErrorOr<ServiceResult> serviceResult,
            Func<ServiceResult, Response> mapper)
        {
            return serviceResult.Match(
                serviceResult=>controllerBase.Ok(mapper(serviceResult)),
                errors=>controllerBase.Problem(errors)
            );
        }
    }
}