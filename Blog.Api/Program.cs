using Blog.Application;
using Blog.Application.Services.Authentication;
using Blog.infra;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplication().AddInfra();
}
var app = builder.Build();


{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
}
app.Run();
