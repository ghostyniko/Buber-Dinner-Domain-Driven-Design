using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Common.Behavoirs;

public class ValidationBehaviour<TRequest,TResponse> :
    IPipelineBehavior<TRequest, TResponse>
        where TRequest:IRequest<TResponse>
        where TResponse:IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehaviour(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();

        }
        
        var validationResult = await _validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return await next();
        }
        var errors = validationResult.Errors
            .Select(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

        return (dynamic)errors;
    }

   
}
