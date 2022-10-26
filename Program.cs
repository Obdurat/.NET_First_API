using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var config = app.Configuration;

app.Run();

public class Product {
    public string? Code { get; set; }

    public string? Name { get; set; }
}



