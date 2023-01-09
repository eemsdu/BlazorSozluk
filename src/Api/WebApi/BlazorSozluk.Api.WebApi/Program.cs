using BlazorSozluk.Infrastructure.Persistance.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureRegistration(builder.Configuration); //bu metot bizden Iconfiguration interface isticek parametrede onu veriyoruz uygulama ilk çalýþtýðýnda bunu ekliyor olucak uygulama çalýþýrken otomatik olarak context oluþacak ama ben migration oluþtururken compair time düzeyinde olucam henüz kod kýsmýnda olucam uygulamam çalýþmýþ olmucak 

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
