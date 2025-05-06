# ASP.NET Core REST API Example

This is a sample ASP.NET Core REST API project demonstrating CRUD operations for a product catalog.

## Project Structure

```
DotNetApi/
├── Controllers/
│   └── ProductsController.cs     # API endpoints for products
├── Data/
│   └── ApiDbContext.cs           # Entity Framework DbContext
├── DTOs/
│   ├── CreateProductDto.cs       # DTO for creating a product
│   ├── ProductDto.cs             # DTO for product data
│   └── UpdateProductDto.cs       # DTO for updating a product
├── Models/
│   └── Product.cs                # Product entity model
├── Repositories/
│   ├── IProductRepository.cs     # Repository interface
│   └── ProductRepository.cs      # Repository implementation
├── Program.cs                    # Application entry point
├── appsettings.json              # Configuration settings
└── appsettings.Development.json  # Development configuration
```

## Technologies Used

- ASP.NET Core 9.0
- Entity Framework Core
- In-Memory Database
- Swagger / OpenAPI

## API Endpoints

### Products

- **GET /api/products** - Get all products
- **GET /api/products/{id}** - Get a specific product
- **POST /api/products** - Create a new product
- **PUT /api/products/{id}** - Update a product
- **DELETE /api/products/{id}** - Delete a product

## How to Run

1. Make sure you have .NET 9.0 SDK installed
2. Clone this repository
3. Navigate to the project directory
4. Run the following commands:

```bash
cd DotNetApi
dotnet restore
dotnet run
```

5. The API will be available at:
   - HTTP: `http://localhost:8080/api/products`
   - HTTPS: `https://localhost:8081/api/products`
   
6. Open your browser and navigate to one of these URLs to access the Swagger UI:
   - HTTP: `http://localhost:8080/swagger`
   - HTTPS: `https://localhost:8081/swagger`

## Example Request and Response

### Request

```http
POST /api/products
Content-Type: application/json

{
  "name": "Sample Product",
  "description": "This is a sample product",
  "price": 29.99
}
```

### Response

```http
HTTP/1.1 201 Created
Content-Type: application/json

{
  "id": 4,
  "name": "Sample Product",
  "description": "This is a sample product",
  "price": 29.99,
  "createdAt": "2023-07-01T12:00:00Z"
}
``` 