# Smart Campus Service Portal

ASP.NET Core MVC application for managing campus service requests and campus events. It demonstrates MVC, Entity Framework Core database connectivity, CRUD operations, model validation, and REST API integration.

## Technology
- ASP.NET Core MVC – .NET 10
- Entity Framework Core 10
- SQLite database
- REST API controllers
- Razor Views and responsive CSS

## Requirements
- Visual Studio 2026 with the .NET 10 SDK, or .NET 10 SDK installed separately
- Internet connection for the first NuGet package restore

## Run in Visual Studio
1. Extract the ZIP file.
2. Open `Practical11_SmartCampus.csproj` in Visual Studio.
3. Wait for NuGet package restore to finish.
4. Select the `https` launch profile.
5. Press `Ctrl + F5`.

The application creates `smartcampus.db` automatically in the project folder on first run and inserts sample service requests and campus events. No SQL Server LocalDB setup, Package Manager Console command, or EF migration is required.

## Run from terminal
```bash
dotnet restore
dotnet run
```

Use the local URL printed in the terminal.

## Features
- Dashboard with request and event summaries
- Submit, list, search, filter, view, edit, and delete service requests
- Add, list, edit, and delete campus events
- Data validation using Data Annotations and ModelState
- SQLite persistence through Entity Framework Core
- REST API endpoints for service requests and campus events

## REST API
| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/CampusApi/requests` | Get all service requests |
| GET | `/api/CampusApi/requests/{id}` | Get one service request |
| POST | `/api/CampusApi/requests` | Create a service request |
| PUT | `/api/CampusApi/requests/{id}` | Update a service request |
| DELETE | `/api/CampusApi/requests/{id}` | Delete a service request |
| GET | `/api/CampusApi/events` | Get all campus events |

### Sample POST JSON
```json
{
  "studentName": "Preet Vora",
  "department": "Computer Engineering",
  "issue": "Wi-Fi Connectivity",
  "description": "Unable to connect to the campus Wi-Fi.",
  "status": "Pending"
}
```

## Database
The SQLite database file is generated automatically as `smartcampus.db`. Keep this file to preserve records. Delete it only if you want the app to recreate a fresh database with sample data.
