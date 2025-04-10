using FluentValidation;
using MediatR;

namespace App.Shared.Middlewares
{
    public class ValidationCqrsMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationCqrsMiddleware(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var validationFailures = (await Task.WhenAll(
                    _validators.Select(validator => validator.ValidateAsync(context, cancellationToken))
                ))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (validationFailures.Any())
            {
                var errorMessage = string.Join(Environment.NewLine,
                    validationFailures.Select(failure => $"{failure.PropertyName}: {failure.ErrorMessage}"));

                throw new ValidationException(errorMessage);
            }

            return await next();
        }
    }





}
