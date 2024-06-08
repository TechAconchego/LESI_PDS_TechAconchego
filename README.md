
# Student TechAconchego Rental App

## Table of Contents

- [Introduction](#introduction)
- [Team Members](#team-members)
- [Features](#features)
- [Getting Started](#getting-started)
- [Dependencies](#dependencies)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This repository contains the source code for a local web application designed to facilitate the rental of rooms or habitats for students. The goal is to provide a user-friendly platform where students can easily find and rent suitable living spaces, while landlords can efficiently manage their rental listings.

## Team Members

| Nome                                      | Número | Função                 |
| ----------------------------------------- | ------ | ---------------------- |
| Adelino Daniel da Rocha Vilaça            | 16939  | Development Team Member|
| António Jorge Magalhães da Rocha          | 26052  | Product Owner          |
| António Rafael Henriques Ferreira         | 26402  | Scrum Master           |
| Marco Silva Alves                         | 23036  | Development Team Member|
| Roberto Salvador Mendes Rodrigues         | 5278   | Development Team Member|

## Features

- User authentication for both students and landlords
- Listing and searching for available rooms or habitats
- Booking and rental management system
- User-friendly interface for seamless navigation
- Responsive design for various devices

## Getting Started

To run this web application locally, follow these steps:

1. **Clone the repository:**
   ```shell
   git clone https://github.com/your-username/student-habitat-rental.git
   ```

2. **Navigate to the project directory:**
   ```shell
   cd student-habitat-rental
   ```

3. **Download and install the .NET SDK:**
   - Visit the [official .NET website](https://dotnet.microsoft.com/download) to download and install the .NET SDK.

4. **Set up the project:**
   ```shell
   dotnet new webapp -o TechAconchego
   cd TechAconchego
   ```

5. **Install Entity Framework Core (for database interactions):**
   ```shell
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```

6. **Configure the database:**
   - Update the `appsettings.json` file with your database connection string.
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=student_habitat;Username=your_username;Password=your_password"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "AllowedHosts": "*"
   }
   ```

7. **Create and apply migrations:**
   ```shell
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

8. **Run the application:**
   ```shell
   dotnet run
   ```

9. **Open your browser and visit:**
   - Navigate to `http://localhost:5000` to view your application.

## Dependencies

- C#
- .NET SDK
- Entity Framework Core
- SQL Server or SQLite

Ensure these dependencies are installed before running the application.

## Usage

1. **Students:**
   - Create accounts, search for available habitats, and book rentals.

2. **Landlords:**
   - List available rooms or habitats, manage bookings, and view tenant information.

3. **Interface:**
   - The application provides an intuitive interface for a seamless user experience.

## Contributing

If you'd like to contribute to the project, please follow these guidelines:

1. **Fork the repository:**
   ```shell
   git clone https://github.com/your-username/student-habitat-rental.git
   ```

2. **Create a new branch:**
   ```shell
   git checkout -b feature-new-feature
   ```

3. **Commit your changes:**
   ```shell
   git commit -m 'Add new feature'
   ```

4. **Push to the branch:**
   ```shell
   git push origin feature-new-feature
   ```

5. **Submit a pull request.**

## License

This project is licensed under the [MIT License](LICENSE).
