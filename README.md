# ConcurrencyWeb
# Product Management with Concurrency Handling

This is a simple .NET Core web application designed to handle CRUD operations (Create, Read, Update, Delete) for products, with special focus on managing concurrency in the database using RowVersion. The project demonstrates the ability to manage conflicts that arise when multiple users try to update the same data simultaneously.

## Features

- **CRUD Operations**: Allows users to create, read, update, and delete product entries.
- **Concurrency Management**: Utilizes `RowVersion` to manage concurrent data updates and avoid data conflicts.
- **Entity Framework Core**: Implements database management and interaction using Entity Framework Core.
- **Razor Pages**: Interactive and user-friendly front-end pages for product listing, updates, and deletions.
- **Error Handling**: Displays appropriate error messages when data conflicts occur, such as when a product is deleted or updated by another user.

## Technologies Used

- **.NET Core**: For backend development and building the RESTful services.
- **Entity Framework Core**: For ORM and database management.
- **Razor Pages**: For creating dynamic and responsive front-end interfaces.
- **SQL Server**: As the database engine.
