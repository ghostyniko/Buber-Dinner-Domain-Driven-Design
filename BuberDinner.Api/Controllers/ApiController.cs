using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DomainErrors = BuberDinner.Domain.Common.Errors.Errors;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController:ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }
            
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            var firstError = errors[0];
            return Problem(firstError);
        }

        private IActionResult Problem(Error error)
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

            return Problem(title: error.Description, statusCode: statusCode);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description);
            }
            return ValidationProblem(modelStateDictionary);
        }

        protected IActionResult ProblemOrResult<ServiceResult,Response>(
            ErrorOr<ServiceResult> serviceResult,
            Func<ServiceResult, Response> mapper)
        {
            return serviceResult.Match(
                serviceResult=>Ok(mapper(serviceResult)),
                errors=>Problem(errors)
            );
        }
    }
}