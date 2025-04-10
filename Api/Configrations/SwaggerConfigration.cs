using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Api.Configrations
{
    public class SwaggerConfigration : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions c)
        {

            c.SwaggerDoc("GeneralAPI", new OpenApiInfo { Title = "General API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            c.OperationFilter<SwaggerCustomHeaderAttribute>();

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}


                    }
                });
            string xmlPath1 = Path.Combine(Environment.CurrentDirectory, "Api.Services.xml");
            string xmlPath2 = Path.Combine(Environment.CurrentDirectory, "Api.xml");

            c.IncludeXmlComments(xmlPath1);
            c.IncludeXmlComments(xmlPath2);

        }
    }

    public class SwaggerUIConfiguration : IConfigureOptions<SwaggerUIOptions>
    {
        public void Configure(SwaggerUIOptions options)
        {

            options.RoutePrefix = "SwaggerPlus";
            options.SwaggerEndpoint("/swagger/GeneralAPI/swagger.json", "General API V1");

        }
    }


    public class SwaggerCustomHeaderAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String"
                },
                Example = new OpenApiString("ar"),
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Type",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String"
                },
                Example = new OpenApiString("Mobile"),
            });
        }
    }
}
