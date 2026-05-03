# Bloggie - Professional ASP.NET Core CMS

## 📝 Overview
A full-stack Content Management System (CMS) built with **ASP.NET Core MVC**, designed for efficient content delivery and administrative management. The application features advanced data grid processing, secure authentication, and cloud-based asset management.

## 🛠️ Tech Stack
* **Backend:** C#, ASP.NET Core 8.0 MVC, Entity Framework Core
* **Database:** Microsoft SQL Server
* **Frontend:** Bootstrap 5, JavaScript (Fetch API), HTML5, CSS3
* **Third-Party APIs:** Cloudinary (Media Hosting)

---

## ⚙️ Database Configuration
The project uses **SQL Server**. 

1. Update the `BloggieDbConnectionString` in `appsettings.json` to point to your local instance.
2. Run the following commands in the **Package Manager Console**:

### For the Bloggie Database:
```powershell
Add-Migration "Initial_Bloggie" -Context BloggieDbContext
Update-Database -Context BloggieDbContext
```
### For the Users Database:
```powershell
Add-Migration "Initial_Auth" -Context AuthDbContext
Update-Database -Context AuthDbContext
```

🖼️ Media Configuration
To be able to see the images on this project, you need to add your own
Cloudinary API keys and secrets to the appsettings.json file.


🧠 Technical Challenges & Solutions
Multi-Parameter State Synchronization: Managed the complexity of maintaining five distinct states (searchQuery, sortBy, sortDirection, pageNumber, and pageSize) across the UI.
Solved the issue of "state loss" by ensuring every interaction (clicking a sort header or a page button) correctly carries the existing parameters back to the Controller via asp-route
attributes.

Asynchronous Repository Pattern: Implemented asynchronous data fetching using Task<IActionResult> and the Repository Pattern. 
This decoupled the controller from the data access layer, ensuring the application remains responsive while performing server-side calculations for total records and page counts.

Case-Sensitive Data Binding: Debugged and resolved issues where route values were failing to bind between the C# Controller and the Razor View due to ViewBag case-sensitivity. 
Ensured consistent naming conventions to maintain the integrity of the data grid's URL parameters.

Sensitive Data Isolation: Established a professional security workflow by decoupling production secrets from the codebase. 
Utilized the .gitignore system to prevent API keys and local environment configurations from being indexed in version control, adhering to industry security standards.
