using JobSearch;
using JobSearch.Shared;
using Microsoft.EntityFrameworkCore;
using JobSearch.Context;
using JobSearch.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<JobSearchContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("JObSearchConnection"))
    .EnableSensitiveDataLogging()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
    ServiceLifetime.Transient);
builder.Services.AddTransient<IJobSearchService, JobSearchService>();

builder.Services.AddSingleton<PageState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
