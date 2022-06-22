using BlogBackend.Database;
using BlogBackend.Database.Interfaces;
using BlogBackend.Middleware;
using BlogBackend.Models;
using BlogBackend.Services;
using BlogBackend.Services.Interfaces;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Blog API",
        Description = "An ASP.NET Core Web API for blog applications"
    });

    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
    {
        Name = "ApiKey",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "Authorization using ApiKey in request header.",
        Scheme = "ApiKeyScheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

    options.EnableAnnotations();

    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

// Register database services
builder.Services.AddSingleton(new MongoClient(builder.Configuration["MONGODB_URI"]).GetDatabase(builder.Configuration["MONGODB_DATABASE"]));
builder.Services.AddSingleton<IPostRepository>(factory => new PostRepository(factory
    .GetRequiredService<IMongoDatabase>()
    .GetCollection<Post>(PostRepository.COLLECTION)
));
builder.Services.AddSingleton<IAuthorRepository>(factory => new AuthorRepository(factory
    .GetRequiredService<IMongoDatabase>()
    .GetCollection<Author>(AuthorRepository.COLLECTION)
));

// Register api services
builder.Services.AddSingleton<AuthMiddleware>();
builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddScoped<IAuthorsService, AuthorsService>();

// Build the application
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<AuthMiddleware>();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
