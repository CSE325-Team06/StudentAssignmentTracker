# Student Assignment Tracker

A Blazor web application that helps students organize assignments, track deadlines, manage courses, and monitor academic progress.

## Features

- User Authentication
- Assignment Management
- Course Management
- Dashboard
- Search and Filtering

## Technology Stack

- Blazor
- ASP.NET Core
- Entity Framework Core
- SQLite
- ASP.NET Identity

## Application Startup

The application registers its interactive Blazor components, SQLite database, and ASP.NET Core Identity services in `Program.cs`. The database connection is read from the `DefaultConnection` setting in `appsettings.json`; pending Entity Framework Core migrations are applied when the application starts.

Requests pass through authentication, authorization, and antiforgery middleware. The `/account/logout` endpoint requires an authenticated user and a valid antiforgery token before ending the session. Razor components support interactive server rendering, while static assets are available anonymously.

## Run Locally

Install the .NET 10 SDK, then run the application from the repository root:

```sh
dotnet run
```

The default SQLite connection stores data in `studentassignmenttracker.db`. To avoid modifying that file while testing, override `ConnectionStrings__DefaultConnection` with a temporary database path.

## End-to-End Verification

With the application running, verify the main user flow in a browser:

1. Register a user and log in.
2. Create a course and confirm it appears on the Courses page.
3. Create an assignment for that course and confirm it appears on the Assignments page and calendar.
4. Mark the assignment complete, then verify its completed state in the dashboard and assignment list.
5. Log out and verify that navigating to a protected page returns to the login page.

## Team Members

- Andrew Awadike
- James Curtis Halls
- Emeribe Stanley Ameiz Chibuike
- Elisha Lawrence Sunday

## Course Information

BYU-Pathway Worldwide

CSE 325 - .NET Software Development

## Project Status

🚧 Currently in development.