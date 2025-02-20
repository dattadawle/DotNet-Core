using ClientService.IHttpService.Contract;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddControllers().AddJsonOptions(config =>
config.JsonSerializerOptions.PropertyNameCaseInsensitive = true);*/
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddHttpClient<HttpClientService>(client => {
    client.BaseAddress = new Uri(builder.Configuration.GetSection("Apiurl").Value);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
