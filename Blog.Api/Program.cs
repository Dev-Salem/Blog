using Blog.Api.Errors;
using Blog.Api.Filters;
using Blog.Api.Middlewares;
using Blog.Application;
using Blog.Application.Services.Authentication;
using Blog.infra;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddControllers();
    builder.Services.AddTransient<GlobalErrorHandlingMiddleware>();
    // builder.Services.AddControllers(options =>
    // {
    //     options.Filters.Add<ErrorHandlingFilterAttribute>();
    // });
    builder.Services.AddSingleton<ProblemDetailsFactory, BlogProblemDetailsFactory>();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplication().AddInfra(configuration: builder.Configuration);
}
var app = builder.Build();


{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    // app.UseMiddleware<GlobalErrorHandlingMiddleware>();
    app.MapControllers();
}
app.Run();
