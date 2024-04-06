var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ConnectionConfigs>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ICrypto, Crypto>();
builder.Services.AddTransient<IDapperRepository,DapperRepository>();
builder.Services.AddTransient<IEmployeeHelpers, EmployeeHelpers>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddServerSideBlazor().AddCircuitOptions(x => x.DetailedErrors = true);
}
else
{
    builder.Services.AddServerSideBlazor();
}

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();