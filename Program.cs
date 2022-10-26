using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var config = app.Configuration;

app.Run();

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



