# TeachingAI

TeachingAI is a robust web application designed to facilitate AI-powered teaching and learning experiences. Built using the latest version of **C# .NET**, it leverages modern tools and frameworks to deliver a seamless user experience. The project uses **MSSQL Server**, managed via **Azure Data Studio**, to ensure efficient and reliable database management.

---

## 🚀 Features

- **User Roles**: Three distinct user roles—Students, Teachers, and Admins.
  - **Students**: Access lessons, complete quizzes, and track progress.
  - **Teachers**: Create courses, upload lessons, and manage quizzes.
  - **Admins**: Oversee the platform with settings and administrative controls.
- **AI Interaction**: Engage with AI for learning assistance and guidance.
- **Progress Tracking**: Monitor lesson completion and course progress.
- **Interactive Quizzes**: Evaluate learning outcomes through integrated quizzes.

---

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core (latest version)
- **Frontend**: Razor Pages / Blazor (depending on your implementation)
- **Database**: MSSQL Server, managed using Azure Data Studio
- **Hosting**: Azure or local deployment (optional)
- **Version Control**: Git & GitHub

---

## 📚 Prerequisites

Ensure the following tools are installed on your machine:

1. **.NET SDK** (latest version)
2. **MSSQL Server** or a compatible instance
3. **Azure Data Studio** for database management
4. **Visual Studio Code** or **Visual Studio** for development
5. **Git** for version control

---

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/Pratham-Gauswami/TeachingAI.git
cd TeachingAI
```

### 2. Setup Database
- Open **Azure Data Studio**.
- Create a new database for the project.
- Update the connection string in the `appsettings.json` file.

### 3. Apply Migrations
```bash
dotnet ef database update
```

### 4. Run the Application
```bash
dotnet run
```
Open your browser and navigate to `http://localhost:5000` (or the specified port).

---

## 🌐 Deployment

To deploy this project, consider using:

1. **Azure App Service** for hosting.
2. **Azure SQL Database** for managing production data.

---

## 📂 Project Structure

- **/Models**: Defines the database entities.
- **/Controllers**: Handles the business logic.
- **/Views**: Contains Razor Pages for the UI.
- **/Migrations**: Tracks database schema changes.
- **appsettings.json**: Configuration file for database connections and app settings.

---

## 🛡️ Security

- Passwords are hashed before storage.
- User roles ensure role-based access control (RBAC).

---

## 🤝 Contributions

Contributions are welcome! If you'd like to add a feature or fix a bug:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature-name`.
3. Commit your changes: `git commit -m "Added feature name"`.
4. Push to the branch: `git push origin feature-name`.
5. Open a pull request.

---

## 📧 Contact

If you have any questions or need support, feel free to reach out:

**Author**: Pratham Gauswami  
**Email**: [prathamg2612@gmail.com](mailto:prathamg2612@gmail.com)
