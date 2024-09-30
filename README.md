# ProductAPI

## Overview

ProductAPI is an ASP.NET Core application designed to manage products. It includes features for logging important events and handling global exceptions in a user-friendly manner.

## Features

- Basic logging system to record errors and important events.
- Global exception handling middleware.
- Connection to an Azure SQL Server database.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Azure SQL Database](https://azure.microsoft.com/en-us/services/sql-database/)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/ProductAPI.git
    cd ProductAPI
    ```

2. Update the `appsettings.json` file with your Azure SQL Database connection string:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=tcp:<your_server_name>.database.windows.net,1433;Initial Catalog=<your_database_name>;Persist Security Info=False;User ID=<your_user_id>;Password=<your_password>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

3. Build and run the application:
    ```sh
    dotnet build
    dotnet run
    ```

### Usage

- The API endpoints are available at `https://localhost:5001/api/v1/products`.
- Use tools like [Postman](https://www.postman.com/) to test the API endpoints.

### Logging and Error Handling

- Logging is configured in `Program.cs` to log to the console and debug output.
- Global exception handling is implemented using a custom middleware `GlobalExceptionMiddleware`.

### Migrations

To apply migrations and update the database schema, use the following commands:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update