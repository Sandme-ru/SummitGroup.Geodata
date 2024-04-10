using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SummitGroup.Geodata.WebApi.Utilities;

public class SubdomainRouteAttribute : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var path in swaggerDoc.Paths.ToList())
        {
            swaggerDoc.Paths.Remove(path.Key);
            var newPathKey = "/summit-group" + path.Key;
            swaggerDoc.Paths.Add(newPathKey, path.Value);
        }
    }
}