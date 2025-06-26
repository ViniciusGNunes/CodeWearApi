using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CodeWearApi.Swagger
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParams = context.MethodInfo.GetParameters()
                .Where(p => p.ParameterType == typeof(IFormFile));

            if (!fileParams.Any()) return;

            operation.RequestBody = new OpenApiRequestBody
            {
                Content =
                {
                    ["multipart/form-data"] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties =
                            {
                                ["imagem"] = new OpenApiSchema { Type = "string", Format = "binary" },
                                ["descricao"] = new OpenApiSchema { Type = "string" },
                                ["produtoId"] = new OpenApiSchema { Type = "integer" }
                            },
                            Required = new HashSet<string> { "imagem", "descricao", "produtoId" }
                        }
                    }
                }
            };
        }
    }
}
