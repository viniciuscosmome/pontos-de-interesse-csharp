using PontosDeInteresse.Src.infra;
using PontosDeInteresse.Src.Modules.PointOfInterest.Validation;
using System.Text.Json;

namespace PontosDeInteresse.Src.Modules.PointOfInterest
{
    public class RegisterPoisFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            List<object> validations = [];
            var inputValidation = context.GetArgument<PoisModel>(0);
            NameValidation checkPoiName = new(inputValidation.Name, true, "Name");
            IntegerValidation checkCoordX = new(inputValidation.CoordX, true, "CoordX");
            IntegerValidation checkCoordY = new(inputValidation.CoordY, true, "CoordY");

            if (!checkPoiName.IsValid)
            {
                validations.Add(checkPoiName.GetError());
            }

            if (!checkCoordX.IsValid)
            {
                validations.Add(checkCoordX.GetError());
            }

            if (!checkCoordY.IsValid)
            {
                validations.Add(checkCoordY.GetError());
            }

            if (validations.Count > 0)
            {
                string responseBody = JsonSerializer.Serialize(new { errors = validations });
                context.HttpContext.Response.StatusCode = 400;
                await context.HttpContext.Response.WriteAsync(responseBody);
            }

            return await next.Invoke(context);
        }
    }

    public class UpdatePoisFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            List<object> validations = [];
            var inputId = context.GetArgument<int>(0);
            var inputData = context.GetArgument<PoisModel>(1);

            IntegerValidation checkId = new(inputId, true, "Id");
            NameValidation checkName = new(inputData.Name, false, "Name");
            IntegerValidation checkCoordX = new(inputData.CoordX, false, "CoordX");
            IntegerValidation checkCoordY = new(inputData.CoordY, false, "CoordY");

            if (!checkId.IsValid)
            {
                validations.Add(checkId.GetError());
            }

            if (!checkName.IsValid)
            {
                validations.Add(checkName.GetError());
            }

            if (!checkCoordX.IsValid)
            {
                validations.Add(checkCoordX.GetError());
            }

            if (!checkCoordY.IsValid)
            {
                validations.Add(checkCoordY.GetError());
            }

            if (validations.Count > 0)
            {
                string responseBody = JsonSerializer.Serialize(new { errors = validations });
                context.HttpContext.Response.StatusCode = 400;
                await context.HttpContext.Response.WriteAsync(responseBody);
            }

            return await next.Invoke(context);
        }
    }
    public class OnlyIdPoisFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            List<object> validations = [];
            var inputId = context.GetArgument<int>(0);

            IntegerValidation checkId = new(inputId, true, "Id");

            if (!checkId.IsValid)
            {
                validations.Add(checkId.GetError());
            }

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
