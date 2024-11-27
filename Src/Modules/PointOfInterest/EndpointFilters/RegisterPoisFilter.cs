using PontosDeInteresse.Src.infra;
using PontosDeInteresse.Src.Modules.PointOfInterest.Validation;
using System.Text.Json;

namespace PontosDeInteresse.Src.Modules.PointOfInterest.EndpointFilters
{
    public class RegisterPoisFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            List<object> validations = [];
            var inputValidation = context.GetArgument<PoisModel>(0);
            NameValidation checkPoiName = new(inputValidation.Name, true, "Name");

            if (!checkPoiName.IsValid)
            {
                validations.Add(checkPoiName.GetError());
            };

            if (validations.Count > 0)
            {
                string responseBody = JsonSerializer.Serialize(new { errors = validations });
                context.HttpContext.Response.StatusCode = 400;
                await context.HttpContext.Response.WriteAsync(responseBody);
            }

            return await next.Invoke(context);
        }
    }
}
