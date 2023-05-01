using ComponentAndHttpErrorsHandling.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ExceptionRecorderService>();
builder.Services.AddHttpClient<BlazorSchoolHttpClientWrapper>((sp, httpClient) => httpClient.Timeout = TimeSpan.FromSeconds(1));

var app = builder.Build();

app.UseExceptionHandler("/BlazorSchoolError");
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
