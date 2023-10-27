using MassTransit;
using Microsoft.OpenApi.Models;
using Spotfy.Business.Consumer;
using Spotfy.Business.Policy;
using Spotfy.Entities.ShareModels;
using SpotfyBusiness.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.Run();
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<ReceiveEmailConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqps://dgonmxbi:NxJ019hezv0Bkb7pGBzaWtBiBfGULV6V@puffin.rmq2.cloudamqp.com/dgonmxbi");
        cfg.Message<SendEmailCommand>(x => x.SetEntityName("SendEmailCommand"));
        cfg.ReceiveEndpoint("send-email-command", c =>
        {
            c.ConfigureConsumer<ReceiveEmailConsumer>(ctx);
        });
    });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
