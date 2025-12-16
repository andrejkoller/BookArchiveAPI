## Short description

This is the backend API for the Bibliotheca application. It provides endpoints to manage users, books, and other related resources.

## 🛠️ Technologies Used

- .NET 9 (C# 13)
- ASP.NET Core Web API
- Entity Framework Core (with SQLite)
- CORS support

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/download.html) (optional, for direct DB access)

## 📦 Installation

1. Clone the repository

```bash
git clone https://github.com/andrejkoller/BibliothecaAPI.git
cd BibliothecaAPI
```

2. Restore dependencies

```bash
dotnet restore
```

3. Apply database migrations

 ```bash
dotnet ef database update
```

4. Run the API

 ```bash
dotnet run --project BibliothecaAPI
```

The API will be available at `https://localhost:7179`.

## 🔗 Related

- Frontend Repository: [bibliotheca-frontend](https://github.com/andrejkoller/bibliotheca-frontend)
