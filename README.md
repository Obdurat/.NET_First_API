
# Minimal .NET API

Hi, this is my first CRUD API using C# with .NET framwork 6.0 that introduced Minimal API's and better Swagger support !
I made this API as a form of learning the .NET framwork and it's tools by starting with a Simple and minimal aproach to a CRUD Operation.
There's no DB connection in this project and all insertions are directly into memory,
meaning, if you add some products and stop the application, all created products by you will be erased !!
But don't you worry that i allready have a seeder running so you can still try it out !


## API Documentation

### You can visualize all Documentation from Swagger when you start the project

```
  your-host/swagger
```


#### Product

```csharp
public class Product {

  public string? Code { get; set; }

  public string? Name { get; set; }
}

```

#### Returns all Products

```
  GET /product
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `none` | `none` | This **Endpoint** Doesn't receive any params |

#### Returns one Product

```
  GET /product/${code}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `code`      | `string` | **Required**. The Code of a Product |

#### Create a new Product

```
  POST /product
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `body`      | `Product` | **Required**. The product Representation in Json |

#### Updates a Product

```
  PUT /product
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `body`      | `Product` | **Required**. The product Representation in Json with an existing code |


#### Deletes a Product

```
  DELETE /product/{code}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `code`      | `string` | **Required**. The code of the product you wish to Delete |

## Running this project

Clone this project

```bash
  git clone https://link-para-o-projeto
```

Enter the directory

```bash
  cd my-project
```

Install all dependencies

```xml
  <Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.1.4" />
  </ItemGroup>

</Project>
```

Go to the root folder and start

```bash
  dotnet run
```


## Shields

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

