using ApiValhalla.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiValhalla.Hubs;
using Microsoft.AspNetCore.Routing.Patterns;

internal class Program
{
    private string _MyCors = "Ceyco";
    private static void Main(string[] args)
    {
        
    var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddSignalR();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ValhallaBack", Version = "v1" });
        });
        // builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
       // builder.Services.AddControllers().AddNewtonsoftJson();

        //builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Conexion"));
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionMaster")));

        builder.Services.AddCors(o => o.AddPolicy("NUXT", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("NUXT");
       app.UseHttpsRedirection();
       
        app.UseRouting();
        app.UseAuthorization();
        /*  app.UseSignalR(routes.MapHub<Notifications>("notif"));
          app.UseEndpoints(endpoints => {
              endpoints.MapHub<Notifications>("notif");
          });*/

        app.MapHub<Notifications>("/notif");
      
        app.MapControllers();

        app.Run();
    }
}