using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Interfaces;
using TestTask.Services;


namespace TestTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();


            services.AddDbContext<MessageContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MessegeConnection")));
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IEncryptedKeyRepository, EncryptedKeyRepository>();
            services.AddScoped<IEncryptService, DefaultEncryptServise>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IEncryptedMessageRepository, EncryptedMessageRepository>();


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(opt => opt.AddPolicy(name: "MessageOrigins",
                policy =>
                {
                    policy.WithOrigins("http://loclalhost:4200")
                    .AllowAnyMethod().
                    AllowAnyHeader();
                }));

            services.AddCors(options =>
            {

                options.AddPolicy(name: "Test",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("Test");




            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}