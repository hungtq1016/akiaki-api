using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowLocalhostCors",
                      policy =>
                      {
                          policy.WithOrigins("https://aki-aki-fe.vercel.app")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddJWT(configuration);
builder.Services.AddSqlServerDbContext<DBContext>(configuration.GetConnectionString("db.host"));
builder.Services.AddCustomMapper<Profile>();

builder.Services.AddScoped<IAuthenService, AuthenService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ILocaleService, LocaleService>();
builder.Services.AddScoped<IEmailService, CEmailService>();
builder.Services.AddScoped<IImageService, CImageService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IInvoiceService, CInvoiceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var context = services.GetRequiredService<DBContext>();

if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.UseCors("allowLocalhostCors");

app.UseWebSockets();

 app.Run();
