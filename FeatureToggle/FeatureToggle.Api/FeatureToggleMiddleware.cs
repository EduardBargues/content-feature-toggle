using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace FeatureToggle.Api
{
    public class FeatureToggleMiddleware
    {
        private RequestDelegate _next;

        public FeatureToggleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool canFeatureBeExecuted = true;

            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute = endpoint?.Metadata.GetMetadata<DefineFeatureAttribute>();
            string featureName = null;
            if (attribute != null)
            {
                featureName = attribute.FeatureName;
                canFeatureBeExecuted = await CanFeatureBeExecuted(featureName);
            }

            if (canFeatureBeExecuted)
            {
                await _next(context);
            }
            else
            {
                await context.Response.WriteAsync($"Feature {featureName} is not active :( ...");
            }
        }

        private Task<bool> CanFeatureBeExecuted(string featureName)
        {
            // Here you would have a call to an external service that has the feature toggle configuration
            return Task.FromResult(false);
        }
    }
}
