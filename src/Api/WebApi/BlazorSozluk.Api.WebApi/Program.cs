using BlazorSozluk.Infrastructure.Persistance.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureRegistration(builder.Configuration); //bu metot bizden Iconfiguration interface isticek parametrede onu veriyoruz uygulama ilk �al��t���nda bunu ekliyor olucak uygulama �al���rken otomatik olarak context olu�acak ama ben migration olu�tururken compair time d�zeyinde olucam hen�z kod k�sm�nda olucam uygulamam �al��m�� olmucak 

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
