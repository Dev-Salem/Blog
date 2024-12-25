using Blog.Api;
using Blog.Application;
using Blog.infra;

var builder = WebApplication.CreateBuilder(args);


{
    builder
        .Services.AddPresentation()
        .AddApplication()
        .AddInfra(configuration: builder.Configuration);
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
