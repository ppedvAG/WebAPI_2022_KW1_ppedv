using WebAPISamples.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPISamples.Data;
using WebApiContrib.Core.Formatter.Csv;
using WebAPISamples.Formatter;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

//Füegen einen DbContext-Klasse hinzu
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbContext")));


builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddDbContext<ProductContext>(opt =>
                opt.UseInMemoryDatabase("ProductInventory"));



builder.Services.AddHttpClient<IVideoService, VideoService>();

builder.Services.AddAuthentication();



// Add services to the container.




builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, new VCardInputFormatter());
    options.OutputFormatters.Insert(0, new VCardOutputFormatter());


}) //Ich bin WebAPI 
    .AddXmlSerializerFormatters()//Zusätzlich können wir jetzt XML 
    .AddCsvSerializerFormatters()
    .AddNewtonsoftJson();


//builder.Services.AddControllersWithViews(); //MVC UI 
//builder.Services.AddRazorPages(); //Razor Page Framework (Nachfolger und grunderneutert von WebForms) 
//builder.Services.AddMvc(); //AddControllersWithViews  + AddRazorPages
builder.Services.AddScoped<ITimeService, TimeService>();

builder.Services.AddTransient<IFileService, FileService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication().AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration, "AzureAd");
app.UseAuthorization();

app.MapControllers(); //Map Controllers navigiert die Request (auf die WebAPI) zum richtigen Controller->Action-Methoden / (URI Ressource) 

app.Run();

//Klassen k�nnen unterhalb erstellt werden 


//Geht nicht -> https://github.com/dotnet/AspNetCore.Docs/issues/24422#event-5818005107
//private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
//{
//    var builder = new ServiceCollection()
//        .AddLogging()
//        .AddMvc()
//        .AddNewtonsoftJson()
//        .Services.BuildServiceProvider();

//    return builder.GetRequiredService<IOptions<MvcOptions>>()
//        .Value
//        .InputFormatters
//        .OfType<NewtonsoftJsonPatchInputFormatter>()
//        .First();
//}
