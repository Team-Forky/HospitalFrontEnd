# HospitalFrontEnd README

## Project Hospitaller 
---
### We are deployed on Azure!

https://hospitallerfe-teamforky.azurewebsites.net/

---
## Web Application

The web application consists of a frontend written in Razor views, HTML, CSS and
Bootstrap. The backend was written in C# using ASP.NET Core 2, Entity Framework Core, and the MVC framework.

The homepage displays the apps logo and allows the user to go to either the Patients or About Us pages. On the Patients page the user will see a list off all patients (brought from the backend and our database) and allow the user to either edit or add entries. 

[User Stories (see list in Trello)](https://trello.com/b/aGbpFaHo/untitled-hospital-app)

[Software Requirements](requirements.md)

[Domain Modeling]()

[ER Diagram](https://drive.google.com/file/d/1i9tU3tyPKcPqTN7nGmVpfJLpzK5pondw/view)


---

## Tools Used
Microsoft Visual Studio Community 2017 (Version 15.5.7)

- C#
- ASP.Net Core
- Entity Framework
- MVC
- Bootstrap
- Azure
- Postman API

---

## Recent Updates

#### V 0.9
*Frontend and backend successfully connected* - 4/13/2020

---

## Getting Started

Clone this repository to your local machine.

```
$ git clone https://github.com/Team-Forky/HospitalFrontEnd
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the /HospitalProjectFrontEnd subdirectory at the root of the repository.
```
cd YourRepo/YourProject
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the /AmandaFE/AmandaFE/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd YourRepo/YourProject
dotnet run
```
Unit testing is included in the AmandaFE/FrontendTesting project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---

## Usage
***[Provide some images of your app with brief description as title]***

### Overview of Recent Posts
![Overview of Recent Posts](https://via.placeholder.com/500x250)

### Creating a Post
![Post Creation](https://via.placeholder.com/500x250)

### Enriching a Post
![Enriching Post](https://via.placeholder.com/500x250)

### Viewing Post Details
![Details of Post](https://via.placeholder.com/500x250)

---
## Data Flow (Frontend, Backend, REST API)
***[Add a clean and clear explanation of what the data flow is. Walk me through it.]***
![Data Flow Diagram](/assets/img/Flowchart.png)

---
## Data Model

### Overall Project Schema
***[Add a description of your DB schema. Explain the relationships to me.]***
![Database Schema](/assets/img/ERD.png)

---
## Model Properties and Requirements

### Blog

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Summary | string | YES |
| Content | string | YES |
| Tags | string(s) | NO |
| Picture | img jpeg/png | NO |
| Sentiment | float | NO |
| Keywords | string(s) | NO |
| Related Posts | links | NO |
| Date | date/time object | YES |


### User

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Name/Author | string | YES |
| Posts | list | YES |

---

## Change Log
***[The change log will list any changes made to the code base. This includes any changes from TA/Instructor feedback]***  
0.9 *Frontend and backend successfully connected* - 4/13/2020

---

## Authors
Andrew Casper
Teddy Damian
Joseph Hangarter
Matthew Johnson

---
