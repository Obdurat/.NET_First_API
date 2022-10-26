using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var config = app.Configuration;
ProductRepository.Init(config);

app.Run();

app.MapGet("/product", () => {
    var products = ProductRepository.GetAll();
    return Results.Ok(products);
});

app.MapGet("/product/{code}", ([FromRouteAttribute] string code) => {
    try {
        var product = ProductRepository.GetOne(code);
        return Results.Ok(product);
    } catch (Exception err) {
        return Results.BadRequest(err);
    }
});

app.MapPost("/product", (Product product) => {
    try {
        var insertedProduct = ProductRepository.Add(product);
        return Results.Created("/product" ,product);
    } catch (Exception err) {
        return Results.BadRequest(err);
    }
});

app.MapPut("/product", (Product product) => {
    try {
        var updtProduct = ProductRepository.Update(product);
        return Results.Ok(updtProduct);
    } catch (Exception e) {
        return Results.BadRequest(e);
    }
});

app.MapDelete("/product/{code}", ([FromRouteAttribute] string code) => {
    try {
        var status = ProductRepository.Remove(code);
        return Results.Ok(status);
    } catch (Exception e) {
        return Results.BadRequest(e);
    };
});

public static class ProductRepository {
    public static List<Product> Products { get; set; } = Products = new List<Product>();

    public static void Init(IConfiguration conf) {
        var productSeed = conf.GetSection("Products").Get<List<Product>>();
        Products = productSeed;
    }

    public static Product Add(Product product) {
        Products.Add(product);
        return product;
    }

    public static List<Product> GetAll() {
        return Products;
    }

    public static Product GetOne(string code) {
        var product = Products.First(p => p.Code == code);
        if (product == null) {
            throw new ArgumentException("No product matches given code: " + code);
        }
        return product;
    }
    
    public static Product Update(Product product) {
        var FoundProduct = Products.First(p => p.Code == product.Code);
        if (FoundProduct == null) {
            throw new ArgumentException("No product matches given code: " + product.Code);
        }
        FoundProduct.Code = product.Code;
        FoundProduct.Name = product.Name;
        return FoundProduct;
    }

    public static string Remove(string code) {
        var product = Products.First(p => p.Code == code);
        if (product == null) {
        throw new ArgumentException("No product matches given code: " + code);
        }
        Products.Remove(product);
        return "Deleted";
    }
}

public class Product {
    public string? Code { get; set; }

    public string? Name { get; set; }
}



