# Brigada Eskwela System

Brigada Eskwela System is a Windows desktop application for managing school Brigada Eskwela activities. It provides user authentication, student registration, volunteer and organization records, donations, utility withdrawals, academic-year management, campus information, and printable reports.

## Features

- User login and role-based application navigation
- Student information and registration management
- Volunteer, organization, donation, and utility records
- Academic-year management
- Campus map and building information
- Dashboard summaries
- RDLC reports for volunteers, donations, and consolidated records

## Technology

- C# Windows Forms
- .NET Framework 4.8
- SQL Server / SQL Server Express
- ADO.NET with `System.Data.SqlClient`
- Microsoft ReportViewer 14
- Visual Studio legacy project format (`.csproj` with `packages.config`)

## Requirements

- Windows
- Visual Studio 2019 or later with the .NET desktop development workload
- .NET Framework 4.8 Developer Pack
- SQL Server or SQL Server Express
- Access to the Brigada Eskwela database and its tables/views
- The Guna UI library referenced by the project

The project currently references `Guna.UI.dll` from an external path:

```text
..\..\Other Files\Guna.UI-Framework-Lib-master\Guna.UI WinForms\.net 4.0\Guna.UI.dll
```

Update that reference or provide the library at the expected location before building.

## Getting Started

1. Clone the repository.

   ```powershell
   git clone https://github.com/dibraa/VNHS-Brigada-System-.git
   cd VNHS-Brigada-System-
   ```

2. Open `BrigadaEskwela_SoftwareDevelopment II.sln` in Visual Studio.

3. Restore the NuGet packages listed in `BrigadaEskwela SoftwareDevelopment II/packages.config`.

4. Configure a SQL Server database containing the required Brigada Eskwela tables and views.

5. Update the application connection string in the project configuration and settings files for the local environment. Do not commit passwords or production connection strings.

6. Confirm that the Guna UI reference resolves, then build and run the solution.

The application opens on the login form. A valid database user and an active school year are required for normal operation.

## Project Structure

```text
BrigadaEskwela_SoftwareDevelopment II.sln
BrigadaEskwela_SoftwareDevelopment II/
├── FRM_Login.cs              # Login screen
├── FRM_Dashboard.cs          # Main navigation and summaries
├── FRM_Students/             # Student registration screens
├── FRM_Records/              # Volunteer and organization records
├── REPORT VIEWER/             # Report export forms
├── Resources/                # Application images and resources
├── *.xsd / *.Designer.cs     # Typed dataset definitions
├── *.rdlc                   # Report definitions
└── packages.config           # NuGet package references
```

## Database Configuration

The application currently uses a SQL Server connection string through `Global.Connection` and the generated application settings. These values are machine-specific and should be replaced with environment-appropriate configuration before deployment.

The code references database objects including:

- `TBL_01_StudentInformation`
- `TBL_02_StudentRegistration`
- `TBL_03_BrigadaVOLUNTEERS2`
- `TBL_04_Brigada_ORGANIZATION`
- `TBL_06_BrigadaDONATIONS2`
- `TBL_09_SchoolYear`
- `TBL_10_Users`
- Several `VIEW_*` objects used by dashboards and reports

The repository does not include a SQL database backup or complete server-side schema. Obtain those separately before running the application.

## Security Notes

This project is an academic/legacy application and requires security hardening before production use:

- Store passwords as salted hashes instead of plaintext values.
- Remove credentials from source code and use protected configuration or managed secrets.
- Parameterize all user-controlled SQL values, including report filters.
- Enforce authorization at the data/service boundary, not only through UI visibility.
- Protect student personal information and restrict report access.

## Build and Test

Build the solution from Visual Studio or with MSBuild on a machine that has the .NET Framework build tools installed:

```powershell
msbuild ".\BrigadaEskwela SoftwareDevelopment II.sln" /p:Configuration=Debug
```

There is currently no automated test project. Database-dependent behavior should be verified against a non-production SQL Server database.

## License

No license file is currently included. Contact the project owner before redistributing or reusing the application.