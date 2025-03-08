# Film Management System

A simple CRUD application for managing films built with ASP.NET Core MVC and SQL Server.

## Features

- View list of all films
- Add new films
- Edit existing film information
- View detailed information about films
- Delete films
- Success and error notifications

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Bootstrap Icons

## Prerequisites

- Visual Studio 2022
- .NET 8 SDK
- SQL Server (LocalDB or higher)

## Getting Started

### Database Setup

1. Open SQL Server Management Studio (SSMS)
2. Connect to your SQL Server instance
3. Execute the SQL script `CreateDatabase.sql` located in the project's root directory

### Application Setup

1. Clone this repository
2. Open the solution in Visual Studio 2022
3. Update the connection string in `appsettings.json` to match your SQL Server configuration:

```json
{
  "ConnectionStrings": {
    "FilmManagementDB": "Data Source=YOUR_SERVER_NAME;Initial Catalog=FilmManagementDB;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

4. Build and run the application

## Project Structure

```
FilmManagementSystem/
├── Controllers/
│   └── FilmsController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   └── Film.cs
├── Views/
│   ├── Films/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
├── Program.cs
├── appsettings.json
└── CreateDatabase.sql
```

## Model Properties

The `Film` model includes the following properties:

- **Id**: Unique identifier (primary key)
- **Title**: Name of the film (required)
- **Director**: Director of the film (required)
- **ReleaseYear**: Year the film was released (required)
- **Genre**: Genre of the film (optional)
- **Duration**: Length of the film in minutes (optional)
- **Description**: Brief description of the film (optional)
- **DateAdded**: Date when the film was added to the database

## Common Issues & Solutions

### SQL Server Connection Issues

If you encounter the error "The certificate chain was issued by an authority that is not trusted":

1. Ensure `TrustServerCertificate=True` is in your connection string
2. For production environments, properly configure SSL certificates

### Application Not Starting

1. Ensure there are no spaces in your project path or name
2. Make sure the correct project is set as the startup project
3. Clean and rebuild the solution

## Further Enhancements

- Add search functionality
- Implement pagination for large datasets
- Add sorting capabilities
- Add file upload for film posters
- Create additional tables (actors, directors, genres)
- Implement user authentication and authorization

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Bootstrap for the UI components
- Entity Framework Core team
- Microsoft for .NET and ASP.NET Core
