## Short description

BookArchiveAPI is a .NET 9 Web API for managing a digital book archive. It allows users to upload, store, and retrieve information about books, including metadata, cover images, and files. The API is designed to be used with a frontend application (e.g., a Vue.js app) and supports CORS for local development.

## Features

- Add, update, delete, and retrieve books
- Upload and serve book files and preview images
- Store metadata such as title, author, genre, format, language, and more
- Enum support for genre, format, and language
- SQLite database for lightweight storage

## Tech Stack

- .NET 9 (C# 13)
- ASP.NET Core Web API
- Entity Framework Core (with SQLite)
- CORS support

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/download.html) (optional, for direct DB access)

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/andrejkoller/BookArchiveAPI.git
cd BookArchiveAPI
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Apply database migrations

 ```bash
dotnet ef database update
```

### 4. Run the API

 ```bash
dotnet run --project BookArchiveAPI
```

The API will be available at `https://localhost:7179`.
