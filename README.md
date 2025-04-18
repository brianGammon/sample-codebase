# Project Tracker Assessment

This is a simple project tracking application built with .NET Core API backend and React frontend. It serves as a sample codebase for evaluating technical skills and proficiency with AI coding assistants.

## Quick Start

### Backend (.NET Core API)
1. Navigate to the backend directory:
   ```bash
   cd backend
   ```

2. Run the API:
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:7186/api/projects`

### Frontend (React)
1. Navigate to the frontend directory:
   ```bash
   cd frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Run the development server:
   ```bash
   npm run dev
   ```
   The frontend will be available at `http://localhost:5173`

## Project Structure

```
ProjectTracker/
├── backend/ (.NET Core Web API)
│   ├── Controllers/
│   ├── Models/
│   ├── Data/
│   └── Program.cs
└── frontend/ (React + TypeScript)
    ├── src/
    │   ├── components/
    │   ├── services/
    │   └── App.tsx
    └── package.json
```

## Evaluation Structure (1 Hour Total)

### Frontend Task (30 minutes)
Add sorting functionality to the project list table. Users should be able to sort by:
- Project name
- Status
- Start date

Include visual indicators for sort direction.

### Backend Task (30 minutes)
Add a new endpoint `/api/projects/stats` that returns:
- Total number of projects
- Count of projects by status
- Average project duration

Update the frontend to display these statistics.