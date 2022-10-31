using IdentityAndJwt.InitExtention;
using IdentityAndJwt.jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//��ʼ��Swagger
builder.Services.InitSwagger();

//��ʼjwt
builder.Services.InitJwt(builder.Configuration.GetSection("JWT").Get<JWTSettings>());

//��ʼidentity
string connStr = builder.Configuration.GetConnectionString("Dbcomnection");
builder.Services.InitIdentity(connStr);

//����Ioptions
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
