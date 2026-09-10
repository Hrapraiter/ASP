using Blazor.Components;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using System.Reflection;

/*

Assembly asm = Assembly.LoadFrom(@"x64/Debug/ConverterCSharp.dll");

Type wrapperType = asm.GetType("ConverterCSharp.Converter");

MethodInfo Dec2Bin = wrapperType.GetMethod("Dec2Bin");
MethodInfo Dec2Hex = wrapperType.GetMethod("Dec2Hex");
MethodInfo Bin2Dec = wrapperType.GetMethod("Bin2Dec");
MethodInfo Hex2Dec = wrapperType.GetMethod("Hex2Dec");
MethodInfo Hex2Bin = wrapperType.GetMethod("Hex2Bin");
MethodInfo Bin2Hex = wrapperType.GetMethod("Bin2Hex");

object instance = Activator.CreateInstance(wrapperType);

Int64 testValue = 255;
Console.WriteLine((string)Dec2Bin.Invoke(instance , new object[] { testValue }));
Console.WriteLine((string)Dec2Hex.Invoke(instance , new object[] { testValue }));
Console.WriteLine((Int64)Bin2Dec.Invoke(instance , new object[] { Dec2Bin.Invoke(instance , new object[] { testValue })}));
Console.WriteLine((Int64)Hex2Dec.Invoke(instance , new object[] { Dec2Hex.Invoke(instance , new object[] { testValue })}));
Console.WriteLine((string)Bin2Hex.Invoke(instance , new object[] { Dec2Bin.Invoke(instance , new object[] { testValue })}));
Console.WriteLine((string)Hex2Bin.Invoke(instance , new object[] { Dec2Hex.Invoke(instance , new object[] { testValue })}));

 */
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
