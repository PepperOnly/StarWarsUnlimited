﻿using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Unlimited.Api
{
  public static class SwaggerLoader
  {
    public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
    {      
      //Handle Auth
      var authenticationEnabled = configuration.GetValue<bool>("AuthenticationSettings:AuthenticationEnabled");

      if (authenticationEnabled)
      {

        services.AddSwaggerGen(options =>
        {
          //Auth
          options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
          {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
          });
          options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
          // Add support for XML comments
          var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
          var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
          options.IncludeXmlComments(xmlPath);
        });
      }
      else
      {
        services.AddSwaggerGen(options =>
        {
          // Add support for XML comments
          var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
          var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
          options.IncludeXmlComments(xmlPath);
        });
      }
    }
  }
}
